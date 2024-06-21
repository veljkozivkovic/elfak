namespace Backend.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class HostController : ControllerBase
{
    private readonly UserManager<Korisnik> _userManager;
    private readonly IMailService _mailService;
    public Context Context { get; set; }
    public HostController(Context context, UserManager<Korisnik> userManager, IMailService _MailService)
    {
        Context = context;
        _userManager = userManager;
        _mailService = _MailService;
    }

    [Authorize(Policy = "RequireHostRole")]
    [HttpPost("createEvent")]
    public async Task<IActionResult> CreateEvent([FromBody] CreateEventDto createEventDto)
    {
        var korisnik = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == User.FindFirstValue(ClaimTypes.Email));

        if (korisnik == null)
        {
            return NotFound("User not found.");
        }

        var banned = await UserUtils.IsBanned(korisnik!, Context);

        if (banned != null)
        {
            return Unauthorized($"You are banned from the platform until {banned.DatumDo.ToShortDateString()}. Reason: {banned.Razlog}");
        }

        string dateTimeString = $"{createEventDto.Datum} {createEventDto.Vreme}";
        DateTime dateTime;
        if (!DateTime.TryParseExact(dateTimeString, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
        {
            return BadRequest("Invalid date and time format.");
        }

        if (dateTime < DateTime.Now)
        {
            return BadRequest("Event date and time must be in the future.");
        }

        var prostor = await Context.Prostori.Include(x => x.PlanoviProstora)
                                            .FirstOrDefaultAsync(x => x.ID == createEventDto.ProstorId);

        if (prostor == null)
        {
            return NotFound("Space not found.");
        }

        List<DraggableItem> draggableItems = new List<DraggableItem>();

        int capacity = 0;

        PlanProstora planProstora = new PlanProstora
        {
            Prostor = prostor
        };

        foreach (DraggableItemDto draggableItemDto in createEventDto.Items!)
        {

            if (draggableItemDto.Tip.ToEnum<TipItema>() == TipItema.Table && draggableItemDto.BrojMesta == 0)
                draggableItemDto.BrojMesta = 4;


            if (draggableItemDto.Tip.ToEnum<TipItema>() == TipItema.Table)
                capacity += draggableItemDto.BrojMesta ?? 0;

            DraggableItem draggableItem = new DraggableItem
            {
                FrontID = draggableItemDto.FrontID,
                Tip = draggableItemDto.Tip.ToEnum<TipItema>(),
                Top = draggableItemDto.Top,
                Left = draggableItemDto.Left,
                Height = draggableItemDto.Height,
                HeightFactor = draggableItemDto.HeightFactor,
                BrojMesta = draggableItemDto.BrojMesta,
                Reserved = draggableItemDto.Reserved,
                Price = draggableItemDto.Price,
                PlanProstora = planProstora
            };

            draggableItems.Add(draggableItem);
        }

        planProstora.DraggableItems = draggableItems;
        planProstora.Kapacitet = capacity;

        List<Line> lines = new List<Line>();

        foreach (LineDto lineDto in createEventDto.Lines!)
        {
            Line line = new Line
            {
                X1 = lineDto.X1,
                Y1 = lineDto.Y1,
                X2 = lineDto.X2,
                Y2 = lineDto.Y2,
                PlanProstora = planProstora
            };
            lines.Add(line);
        }

        planProstora.Lines = lines;

        SurfaceDimension surfaceDimension = new SurfaceDimension
        {
            Width = createEventDto.SurfaceDimension!.Width,
            Height = createEventDto.SurfaceDimension!.Height,
            PlanProstora = planProstora
        };

        await Context.SurfaceDimensions.AddAsync(surfaceDimension);
        await Context.PlanoviProstora.AddAsync(planProstora);

        var rezervacijaProstora = new RezervacijaProstora
        {
            VremeOd = dateTime.AddHours(-12),
            VremeDo = dateTime.AddHours(12),
            Status = StatusRezervacije.WaitingConfirmation,
            Prostor = prostor
        };

        await Context.RezervacijeProstora.AddAsync(rezervacijaProstora);

        var dogadjaj = new Dogadjaj
        {
            Naziv = createEventDto.Naziv,
            Opis = createEventDto.Opis,
            Vreme = dateTime,
            Organizator = korisnik,
            VideoLink = createEventDto.Video,
            Status = StatusDogadjaja.WaitingForSpaceApproval,
            Slika = "",
            PlanProstora = planProstora,
        };

        await Context.Dogadjaji.AddAsync(dogadjaj);

        dogadjaj.RezervacijaProstora = rezervacijaProstora;
        rezervacijaProstora.Dogadjaj = dogadjaj;

        List<Tag> tags = new List<Tag>();
        foreach (var tag in createEventDto.Tags!)
        {
            var existingTag = await Context.Tagovi.Include(x => x.Dogadjaji).FirstOrDefaultAsync(x => x.TagName == tag);
            if (existingTag != null)
            {
                tags.Add(existingTag);
                existingTag.Dogadjaji!.Add(dogadjaj);
            }
            else
            {
                Tag newTag = new Tag
                {
                    TagName = tag,
                    Dogadjaji = new List<Dogadjaj> { dogadjaj }
                };
                await Context.Tagovi.AddAsync(newTag);
                tags.Add(newTag);
            }
        }

        await Context.SaveChangesAsync();
        return Ok(dogadjaj.ID);

    }

    [Authorize(Policy = "RequireHostRole")]
    [HttpGet("getAvailableSpaces/{date}/{time}/{location}/{capacity}")]
    public async Task<ActionResult> GetAvailableSpaces(string date, string time, string location, int capacity)
    {
        var korisnik = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == User.FindFirstValue(ClaimTypes.Email));

        if (korisnik == null)
        {
            return NotFound("User not found.");
        }

        var banned = await UserUtils.IsBanned(korisnik!, Context);

        if (banned != null)
        {
            return Unauthorized($"You are banned from the platform until {banned.DatumDo.ToShortDateString()}. Reason: {banned.Razlog}");
        }

        string dateTimeString = $"{date} {time}";
        DateTime dateTime = DateTime.Now;
        if (!DateTime.TryParseExact(dateTimeString, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
        {
            return BadRequest("Invalid date and time format.");
        }

        var spaces = await Context.Prostori.Include(x => x.Rezervacije)
                                           .Include(x => x.PlanoviProstora!)
                                           .ThenInclude(x => x.DraggableItems)
                                           .Include(x => x.PlanoviProstora!)
                                           .ThenInclude(x => x.Dogadjaj)
                                           .Where(x => x.Rezervacije!.All(y => !(dateTime >= y.VremeOd && dateTime <= y.VremeDo))
                                                    && (location != "null" ? x.Grad + ", " + x.Drzava == location : true)
                                                    && (capacity != -1 ? x.PlanoviProstora!
                                                                        .Where(y => y.Dogadjaj == null)
                                                                        .FirstOrDefault()!
                                                                        .Kapacitet >= capacity : true)
                                           )
                                           .Select(x => new SpaceBasicDto
                                           {
                                               ID = x.ID,
                                               Grad = x.Grad,
                                               Drzava = x.Drzava,
                                               Adresa = x.Adresa,
                                               Kapacitet = x.PlanoviProstora!.Where(y => y.Dogadjaj == null).FirstOrDefault()!.Kapacitet
                                           })
                                           .ToListAsync();

        return Ok(spaces);
    }

    [Authorize(Policy = "RequireHostRole")]
    [HttpGet("getSpacePlan/{spaceId}")]
    public async Task<ActionResult> GetSpacePlan(int spaceId)
    {
        var korisnik = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == User.FindFirstValue(ClaimTypes.Email));

        if (korisnik == null)
        {
            return NotFound("User not found.");
        }

        var banned = await UserUtils.IsBanned(korisnik!, Context);

        if (banned != null)
        {
            return Unauthorized($"You are banned from the platform until {banned.DatumDo.ToShortDateString()}. Reason: {banned.Razlog}");
        }

        SpaceDto? spacePlan = await Context.PlanoviProstora.Include(x => x.Prostor)
                                               .Include(x => x.DraggableItems)
                                               .Include(x => x.Lines)
                                               .Include(x => x.SurfaceDimension)
                                               .Where(x => x.Prostor!.ID == spaceId && x.Dogadjaj == null)
                                               .Select(x => new SpaceDto
                                               {
                                                   ID = x.ID,
                                                   DraggableItems = x.DraggableItems!.Select(y => new DraggableItemDto
                                                   {
                                                       ID = y.ID,
                                                       FrontID = y.FrontID,
                                                       Tip = y.Tip.ToString().ToLower(),
                                                       Top = y.Top,
                                                       Left = y.Left,
                                                       Height = y.Height,
                                                       HeightFactor = y.HeightFactor,
                                                       BrojMesta = y.BrojMesta,
                                                       Reserved = y.Reserved,
                                                       Price = y.Price
                                                   }).ToList(),
                                                   Lines = x.Lines!.Select(y => new LineDto
                                                   {
                                                       X1 = y.X1,
                                                       Y1 = y.Y1,
                                                       X2 = y.X2,
                                                       Y2 = y.Y2
                                                   }).ToList(),
                                                   SurfaceDimension = new SurfaceDimensionDto
                                                   {
                                                       Width = x.SurfaceDimension!.Width,
                                                       Height = x.SurfaceDimension!.Height
                                                   }
                                               })
                                               .FirstOrDefaultAsync();

        return Ok(spacePlan);
    }

    [Authorize(Policy = "RequireHostRole")]
    [HttpDelete("cancelEvent/{id}")]
    public async Task<IActionResult> CancelEvent([FromRoute] int id)
    {
        var korisnik = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == User.FindFirstValue(ClaimTypes.Email));

        if (korisnik == null)
        {
            return NotFound("User not found.");
        }

        var banned = await UserUtils.IsBanned(korisnik!, Context);

        if (banned != null)
        {
            return Unauthorized($"You are banned from the platform until {banned.DatumDo.ToShortDateString()}. Reason: {banned.Razlog}");
        }

        var dogadjaj = await Context.Dogadjaji.Include(x => x.Organizator).Include(x => x.RezervacijaProstora).Include(x => x.Tagovi).FirstOrDefaultAsync(x => x.ID == id);

        if (dogadjaj == null)
        {
            return NotFound("Event not found.");
        }

        if (dogadjaj.Organizator != korisnik)
        {
            return Unauthorized("You are not the host of this event.");
        }

        dogadjaj.Tagovi!.Clear();
        await Context.SaveChangesAsync();

        var rezervacijaProstora = dogadjaj.RezervacijaProstora;

        var visitors = await Context.Rezervacije.Include(x => x.Korisnik)
                                                .Where(x => x.Dogadjaj == dogadjaj)
                                                .Select(x => new
                                                {
                                                    Email = x.Korisnik!.Email,
                                                    Name = x.Korisnik.Ime + " " + x.Korisnik.Prezime,
                                                })
                                                .Distinct()
                                                .ToListAsync();

        var dogadjajNaziv = dogadjaj.Naziv;
        var dogadjajVreme = dogadjaj.Vreme.ToString("dd.MM.yyyy. HH:mm");

        Context.Dogadjaji.Remove(dogadjaj);
        Context.RezervacijeProstora.Remove(dogadjaj.RezervacijaProstora!);
        await Context.SaveChangesAsync();

        visitors.ForEach((x) =>
        {
            var mailData = new HTMLMailData
            {
                EmailToId = x.Email!,
                EmailToName = x.Name,
                EmailSubject = "Event you have reservation for is cancelled",
                EventName = dogadjajNaziv,
                EventDate = dogadjajVreme,
                MailType = "EventCancelled"
            };

            _mailService.SendHTMLMailFireAndForget(mailData);
        });

        return Ok();
    }

    [Authorize(Policy = "RequireHostRole")]
    [HttpGet("getIncomingEvents")]
    public async Task<ActionResult<List<EventForListDto>>> GetIncomingEvents()
    {
        var korisnik = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == User.FindFirstValue(ClaimTypes.Email));

        if (korisnik == null)
        {
            return NotFound("User not found.");
        }

        var banned = await UserUtils.IsBanned(korisnik!, Context);

        if (banned != null)
        {
            return Unauthorized($"You are banned from the platform until {banned.DatumDo.ToShortDateString()}. Reason: {banned.Razlog}");
        }

        var dogadjaji = await Context.Dogadjaji
                                    .Where(x => x.Organizator == korisnik
                                            && x.Vreme > DateTime.Now
                                            && x.Status == StatusDogadjaja.Active)
                                    .Select(x => new EventForListDto
                                    {
                                        ID = x.ID,
                                        Naziv = x.Naziv,
                                        Slika = x.Slika,
                                        Datum = x.Vreme
                                    })
                                    .ToListAsync();

        return Ok(dogadjaji);
    }

    [Authorize(Policy = "RequireHostRole")]
    [HttpGet("getPastEvents")]
    public async Task<ActionResult> GetPastEvents()
    {
        var korisnik = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == User.FindFirstValue(ClaimTypes.Email));

        if (korisnik == null)
        {
            return NotFound("User not found.");
        }

        var banned = await UserUtils.IsBanned(korisnik!, Context);

        if (banned != null)
        {
            return Unauthorized($"You are banned from the platform until {banned.DatumDo.ToShortDateString()}. Reason: {banned.Razlog}");
        }

        var dogadjaji = await Context.Dogadjaji
                                    .Where(x => x.Organizator == korisnik
                                            && x.Vreme < DateTime.Now
                                            && x.Status == StatusDogadjaja.Passed)
                                    .Select(x => new EventForListDto
                                    {
                                        ID = x.ID,
                                        Naziv = x.Naziv,
                                        Slika = x.Slika,
                                        Datum = x.Vreme
                                    })
                                    .ToListAsync();

        return Ok(dogadjaji);
    }

    [Authorize(Policy = "RequireHostRole")]
    [HttpGet("getStatistics")]
    public async Task<ActionResult> GetStatistics()
    {
        var korisnik = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == User.FindFirstValue(ClaimTypes.Email));

        if (korisnik == null)
        {
            return NotFound("User not found.");
        }

        var banned = await UserUtils.IsBanned(korisnik!, Context);

        if (banned != null)
        {
            return Unauthorized($"You are banned from the platform until {banned.DatumDo.ToShortDateString()}. Reason: {banned.Razlog}");
        }

        var dogadjaji = await Context.Dogadjaji
                                    .Include(x => x.Ocene)
                                    .Include(x => x.Rezervacije!)
                                    .ThenInclude(x => x.Sto)
                                    .Where(x => x.Organizator == korisnik
                                            && x.Vreme < DateTime.Now
                                            && x.Status == StatusDogadjaja.Passed)
                                    .ToListAsync();

        int hostedEvents = dogadjaji.Count;

        int totalReservations = dogadjaji.Count == 0 ? 0 : dogadjaji.Sum(x => (x.Rezervacije != null && x.Rezervacije.Count != 0) ? x.Rezervacije.Count : 0);

        int estimatedEarnings = dogadjaji.Count == 0 ? 0 : dogadjaji.Sum(x => (x.Rezervacije != null && x.Rezervacije.Count != 0) ? x.Rezervacije?.Sum(y => y.Sto?.Price * y.Sto?.BrojMesta) : 0) ?? 0;

        double? averageRating = dogadjaji.Count == 0 ? 0 : dogadjaji.Average(x => (x.Ocene != null && x.Ocene.Count != 0) ? x.Ocene?.Average(y => y.Vrednost) : 0);

        var statistics = new
        {
            HostedEvents = hostedEvents,
            AverageRating = averageRating,
            Reservations = totalReservations,
            EstimatedEarnings = estimatedEarnings
        };

        return Ok(statistics);
    }

    [Authorize(Policy = "RequireHostRole")]
    [HttpGet("getReviewsForEvent/{id}")]
    public async Task<ActionResult> GetReviewsForEvent(int id)
    {
        var korisnik = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == User.FindFirstValue(ClaimTypes.Email));

        if (korisnik == null)
        {
            return NotFound("User not found.");
        }

        var banned = await UserUtils.IsBanned(korisnik!, Context);

        if (banned != null)
        {
            return Unauthorized($"You are banned from the platform until {banned.DatumDo.ToShortDateString()}. Reason: {banned.Razlog}");
        }

        var dogadjaj = await Context.Dogadjaji.Include(x => x.Organizator).FirstOrDefaultAsync(x => x.ID == id);

        if (dogadjaj == null)
        {
            return NotFound("Event not found.");
        }

        if (dogadjaj.Organizator != korisnik)
        {
            return Unauthorized("You are not the host of this event.");
        }

        var ocene = await Context.Ocene.Include(x => x.Korisnik)
                                                .Where(x => x.Dogadjaj == dogadjaj)
                                                .Select(x => new
                                                {
                                                    Avatar = x.Korisnik!.SlikaProfila,
                                                    Name = x.Korisnik.Ime + " " + x.Korisnik.Prezime,
                                                    Rating = x.Vrednost,
                                                    Comment = x.Komentar,
                                                    Time = DateUtils.TimeAgo(x.VremeKomentara)
                                                })
                                                .ToListAsync();

        return Ok(ocene);
    }


    [Authorize(Policy = "RequireHostRole")]
    [HttpGet("getEventDetails/{id}")]
    public async Task<ActionResult> GetEventDetails(int id)
    {
        var korisnik = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == User.FindFirstValue(ClaimTypes.Email));

        if (korisnik == null)
        {
            return NotFound("User not found.");
        }

        var banned = await UserUtils.IsBanned(korisnik!, Context);

        if (banned != null)
        {
            return Unauthorized($"You are banned from the platform until {banned.DatumDo.ToShortDateString()}. Reason: {banned.Razlog}");
        }

        var dogadjaj = await Context.Dogadjaji.Include(x => x.PlanProstora)
                                               .ThenInclude(x => x!.Prostor)
                                               .ThenInclude(x => x!.VlasnikProstora)
                                               .Include(x => x.Tagovi)
                                               .Include(x => x.Rezervacije)
                                               .Where(x => x.ID == id)
                                               .Select(x => new
                                               {
                                                   EventName = x.Naziv,
                                                   Description = x.Opis,
                                                   Tags = x.Tagovi != null ? x.Tagovi!.Select(y => y.TagName).ToList() : new List<string>(),
                                                   Date = x.Vreme.ToString("yyyy-MM-dd"),
                                                   Time = x.Vreme.ToString("HH:mm"),
                                                   Video = x.VideoLink,
                                                   Capacity = x.PlanProstora!.Kapacitet,
                                                   Location = x.PlanProstora!.Prostor!.Grad + ", " + x.PlanProstora!.Prostor!.Drzava,
                                                   Address = x.PlanProstora!.Prostor!.Adresa,
                                                   PhoneNumber = x.PlanProstora!.Prostor!.VlasnikProstora!.Telefon,
                                                   ReservedTables = x.Rezervacije != null ? x.Rezervacije!.Count() : 0,
                                                   MaxTables = x.PlanProstora!.DraggableItems!.Where(y => y.Tip == TipItema.Table).Count(),
                                                   TotalEarnings = x.Rezervacije != null ? x.Rezervacije!.Sum(y => y.Sto!.Price * y.Sto!.BrojMesta) : 0,
                                               })
                                               .FirstOrDefaultAsync();

        return Ok(dogadjaj);
    }

    [Authorize(Policy = "RequireHostRole")]
    [HttpPut("changeEventDetails")]
    public async Task<ActionResult> ChangeEventDetails([FromBody] ChangeEventDto changeEventDto)
    {
        var korisnik = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == User.FindFirstValue(ClaimTypes.Email));

        if (korisnik == null)
        {
            return NotFound("User not found.");
        }

        var banned = await UserUtils.IsBanned(korisnik!, Context);

        if (banned != null)
        {
            return Unauthorized($"You are banned from the platform until {banned.DatumDo.ToShortDateString()}. Reason: {banned.Razlog}");
        }

        var dogadjaj = await Context.Dogadjaji.Include(x => x.Tagovi)
                                                .Include(x => x.Organizator)
                                                .Include(x => x.RezervacijaProstora)
                                                .Where(x => x.ID == changeEventDto.ID && x.Organizator == korisnik)
                                                .FirstOrDefaultAsync();

        if (dogadjaj == null)
        {
            return NotFound("Event not found.");
        }

        string dateTimeString = $"{changeEventDto.Datum} {changeEventDto.Vreme}";
        DateTime dateTime;
        if (!DateTime.TryParseExact(dateTimeString, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
        {
            return BadRequest("Invalid date and time format.");
        }

        if (dateTime < DateTime.Now)
        {
            return BadRequest("Event date and time must be in the future.");
        }

        if (dogadjaj.Vreme.ToShortDateString() != dateTime.ToShortDateString())
        {
            dogadjaj.Status = StatusDogadjaja.WaitingForSpaceApproval;

            var rezervacijaProstora = dogadjaj.RezervacijaProstora;

            rezervacijaProstora!.VremeOd = dateTime.AddHours(-12);
            rezervacijaProstora.VremeDo = dateTime.AddHours(12);
            rezervacijaProstora.Status = StatusRezervacije.WaitingConfirmation;

            var visitors = await Context.Rezervacije.Include(x => x.Korisnik)
                                                .Where(x => x.Dogadjaj == dogadjaj)
                                                .Select(x => new
                                                {
                                                    Email = x.Korisnik!.Email,
                                                    Name = x.Korisnik.Ime + " " + x.Korisnik.Prezime,
                                                })
                                                .Distinct()
                                                .ToListAsync();

            var dogadjajNaziv = dogadjaj.Naziv;
            var dogadjajVreme = dogadjaj.Vreme.ToString("dd.MM.yyyy. HH:mm");
            var novoVreme = dateTime.ToString("dd.MM.yyyy HH:mm");

            visitors.ForEach((x) =>
            {
                var mailData = new HTMLMailData
                {
                    EmailToId = x.Email!,
                    EmailToName = x.Name,
                    EmailSubject = "Event you have reservation for is rescheduled",
                    EventName = dogadjajNaziv,
                    EventDate = dogadjajVreme,
                    RescheduledDate = novoVreme,
                    MailType = "EventRescheduled"
                };

                _mailService.SendHTMLMailFireAndForget(mailData);
            });

        }

        dogadjaj.Naziv = changeEventDto.Naziv;
        dogadjaj.Opis = changeEventDto.Opis;
        dogadjaj.Vreme = dateTime;
        dogadjaj.VideoLink = changeEventDto.Video;

        List<Tag> tags = new List<Tag>();

        dogadjaj.Tagovi!.Clear();
        await Context.SaveChangesAsync();

        foreach (var tag in changeEventDto.Tagovi!)
        {
            var existingTag = await Context.Tagovi.Include(x => x.Dogadjaji).FirstOrDefaultAsync(x => x.TagName == tag);
            if (existingTag != null)
            {
                tags.Add(existingTag);
                existingTag.Dogadjaji!.Add(dogadjaj);
            }
            else
            {
                Tag newTag = new Tag
                {
                    TagName = tag,
                    Dogadjaji = new List<Dogadjaj> { dogadjaj }
                };
                await Context.Tagovi.AddAsync(newTag);
                tags.Add(newTag);
            }
        }

        await Context.SaveChangesAsync();

        return Ok();
    }

    [Authorize(Policy = "RequireHostRole")]
    [HttpGet("getReservations/{id}")]
    public async Task<ActionResult> GetReservations(int id)
    {
        var korisnik = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == User.FindFirstValue(ClaimTypes.Email));

        if (korisnik == null)
        {
            return NotFound("User not found.");
        }

        var banned = await UserUtils.IsBanned(korisnik!, Context);

        if (banned != null)
        {
            return Unauthorized($"You are banned from the platform until {banned.DatumDo.ToShortDateString()}. Reason: {banned.Razlog}");
        }

        var dogadjaji = await Context.Rezervacije.Include(x => x.Dogadjaj)
                                               .Include(x => x.Korisnik)
                                               .Include(x => x.Sto)
                                               .Where(x => x.Dogadjaj!.ID == id)
                                               .Select(x => new
                                               {
                                                   ReservationID = x.ID,
                                                   Name = x.Korisnik!.Ime + " " + x.Korisnik.Prezime,
                                                   Email = x.Korisnik.Email,
                                                   ReservationTime = x.VremeRezervacije,
                                                   TableID = x.Sto!.ID,
                                                   Seats = x.BrojMesta,
                                                   Price = x.Sto!.Price * x.Sto!.BrojMesta,
                                               })
                                               .ToListAsync();

        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append("ReservationID   | Name               | Email                          | Reservation Time    | TableID | Seats | TotalPrice\n");
        stringBuilder.Append("------------------------------------------------------------------------------------------------------------------------------------\n");

        string format = "{0,-15} | {1,-18} | {2,-30} | {3,-19} | {4,-7} | {5,-5} | ${6,-10}\n";

        dogadjaji.ForEach(x =>
        {
            stringBuilder.AppendFormat(format, x.ReservationID, x.Name, x.Email, x.ReservationTime, x.TableID, x.Seats, x.Price);
        });

        return Ok(stringBuilder.ToString());
    }

    [Authorize(Policy = "RequireHostRole")]
    [HttpGet("getEventSpace/{eventId}")]
    public async Task<ActionResult> GetEventSpace(int eventId)
    {
        var korisnik = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == User.FindFirstValue(ClaimTypes.Email));

        if (korisnik == null)
        {
            return NotFound("User not found.");
        }

        var banned = await UserUtils.IsBanned(korisnik!, Context);

        if (banned != null)
        {
            return Unauthorized($"You are banned from the platform until {banned.DatumDo.ToShortDateString()}. Reason: {banned.Razlog}");
        }

        var organizator = await Context.Dogadjaji.Include(x => x.Organizator).Where(x => x.ID == eventId).Select(x => x.Organizator).FirstOrDefaultAsync();

        if (organizator != korisnik)
        {
            return Unauthorized("You are not the host of this event.");
        }

        var spacePlan = await Context.PlanoviProstora.Include(x => x.Dogadjaj)
                                               .ThenInclude(x => x!.Organizator)
                                               .Include(x => x.DraggableItems!)
                                               .ThenInclude(x => x.Rezervacija)
                                               .Include(x => x.Lines)
                                               .Include(x => x.SurfaceDimension)
                                               .Where(x => x.Dogadjaj != null && x.Dogadjaj!.ID == eventId)
                                                  .Select(x => new SpaceDto
                                                  {
                                                      ID = x.ID,
                                                      DraggableItems = x.DraggableItems!.Select(y => new DraggableItemDto
                                                      {
                                                          ID = y.ID,
                                                          FrontID = y.FrontID,
                                                          Tip = y.Tip.ToString().ToLower(),
                                                          Top = y.Top,
                                                          Left = y.Left,
                                                          Height = y.Height,
                                                          HeightFactor = y.HeightFactor,
                                                          BrojMesta = y.BrojMesta,
                                                          Reserved = y.Reserved,
                                                          Price = y.Price,
                                                          ReservationId = y.Reserved == true ? y.Rezervacija!.ID : -1,
                                                          ReservedSeats = y.Reserved == true ? y.Rezervacija!.BrojMesta : -1,
                                                      }).ToList(),
                                                      Lines = x.Lines!.Select(y => new LineDto
                                                      {
                                                          X1 = y.X1,
                                                          Y1 = y.Y1,
                                                          X2 = y.X2,
                                                          Y2 = y.Y2
                                                      }).ToList(),
                                                      SurfaceDimension = new SurfaceDimensionDto
                                                      {
                                                          Width = x.SurfaceDimension!.Width,
                                                          Height = x.SurfaceDimension!.Height
                                                      }
                                                  })
                                               .FirstOrDefaultAsync();

        return Ok(spacePlan);
    }

}
