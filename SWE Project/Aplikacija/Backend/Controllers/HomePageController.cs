namespace Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class HomePageController : ControllerBase
{
    public Context Context { get; set; }
    private readonly UserManager<Korisnik> _userManager;

    public HomePageController(Context context, UserManager<Korisnik> userManager)
    {
        Context = context;
        _userManager = userManager;
    }

    [AllowAnonymous]
    [HttpGet("getHighlights")]
    public async Task<IActionResult> GetHighlights()
    {
        var highlights = await Context.Dogadjaji.Include(x => x.Rezervacije)
                                                .Where(x => x.VideoLink != null && x.Status == StatusDogadjaja.Passed)
                                                .OrderByDescending(x => x.Rezervacije!.Count)
                                                .Select(x => new
                                                {
                                                    x.ID,
                                                    EmbedSrc = x.VideoLink,
                                                    x.Vreme
                                                })
                                                .Take(8)
                                                .ToListAsync();

        var highlightsFiltered = highlights.Where(x => (x.Vreme + TimeSpan.FromDays(7)) < DateTime.Now)
                                                    .Select(x => new
                                                    {
                                                        x.ID,
                                                        x.EmbedSrc
                                                    })
                                                    .ToList();

        if (highlightsFiltered.Count == 0)
            highlightsFiltered = highlights.Where(x => (x.Vreme + TimeSpan.FromDays(14)) < DateTime.Now)
                                                    .Select(x => new
                                                    {
                                                        x.ID,
                                                        x.EmbedSrc
                                                    })
                                                    .ToList();

        return Ok(highlights);
    }

    [AllowAnonymous]
    [HttpGet("getAllEvents/{currentPage}")]
    public async Task<ActionResult<List<FullEventDto>>> GetAllEvents(int currentPage)
    {
        var events = await Context.Dogadjaji
                                    .Include(x => x.Organizator)
                                    .Include(x => x.Tagovi)
                                    .Include(x => x.RezervacijaProstora)
                                    .Where(x => x.Status == StatusDogadjaja.Active)
                                    .OrderBy(x => x.Vreme)
                                    .Skip(currentPage * 10)
                                    .Take(10)
                                    .Select(x => new FullEventDto
                                    {
                                        ID = x.ID,
                                        Naziv = x.Naziv,
                                        Slika = x.Slika,
                                        Datum = x.Vreme.ToString("dd.MM.yyyy."),
                                        Vreme = x.Vreme.ToString("HH:mm"),
                                        Lokacija = $"{x.RezervacijaProstora!.Prostor!.Grad}, {x.RezervacijaProstora.Prostor.Drzava}",
                                        OrganizatorID = x.Organizator!.Id.ToString(),
                                        Organizator = $"{x.Organizator!.Ime} {x.Organizator!.Prezime}",
                                    })
                                    .ToListAsync();
        if (events.Count == 0)
            return NotFound();

        return Ok(events);
    }

    [AllowAnonymous]
    [HttpGet("getFilteredEvents/{currentPage}")]
    public async Task<ActionResult<List<FullEventDto>>> GetFilteredEvents(int currentPage, [FromQuery] string? location, [FromQuery] string? search, [FromQuery] string? date, [FromQuery] string[]? tags)
    {
        DateTime dateParsed = DateTime.Now;
        bool dateFilter = !String.IsNullOrEmpty(date) && DateTime.TryParseExact(date, "dd.MM.yyyy.", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateParsed);

        var events = await Context.Dogadjaji
                                    .Include(x => x.Organizator)
                                    .Include(x => x.Tagovi)
                                    .Include(x => x.RezervacijaProstora)
                                    .Where(x => x.Status == StatusDogadjaja.Active
                                                && (String.IsNullOrEmpty(location) ? true : (x.RezervacijaProstora!.Prostor!.Grad + ", " + x.RezervacijaProstora.Prostor.Drzava) == location)
                                                && (String.IsNullOrEmpty(search) ? true : x.Naziv.ToLower().Contains(search.ToLower()))
                                                && (!dateFilter ? true : x.Vreme.Date == dateParsed.Date)
                                                && (tags!.Length == 0 ? true : x.Tagovi!.Any(y => tags.Contains(y.TagName))))
                                    .OrderBy(x => x.Vreme)
                                    .Skip(currentPage * 10)
                                    .Take(10)
                                    .Select(x => new FullEventDto
                                    {
                                        ID = x.ID,
                                        Naziv = x.Naziv,
                                        Slika = x.Slika,
                                        Datum = x.Vreme.ToString("dd.MM.yyyy."),
                                        Vreme = x.Vreme.ToString("HH:mm"),
                                        Lokacija = $"{x.RezervacijaProstora!.Prostor!.Grad}, {x.RezervacijaProstora.Prostor.Drzava}",
                                        OrganizatorID = x.Organizator!.Id.ToString(),
                                        Organizator = $"{x.Organizator!.Ime} {x.Organizator!.Prezime}",
                                    })
                                    .ToListAsync();

        return Ok(events);
    }

    [AllowAnonymous]
    [HttpGet("getLocations")]
    public async Task<IActionResult> GetLocations()
    {
        var locations = await Context.Prostori
                                        .Select(x => new
                                        {
                                            x.Grad,
                                            x.Drzava
                                        })
                                        .Distinct()
                                        .OrderBy(x => x.Drzava)
                                        .ThenBy(x => x.Grad)
                                        .ToListAsync();

        var locationStrings = locations
                                .Select(x => $"{x.Grad}, {x.Drzava}")
                                .ToList();

        return Ok(locationStrings);
    }

    [AllowAnonymous]
    [HttpGet("getOrganizers")]
    public async Task<IActionResult> GetOrganizers()
    {
        var organizers = await Context.Dogadjaji
                                    .Include(x => x.Organizator)
                                    .Select(x => $"{x.Organizator!.Ime} {x.Organizator!.Prezime}")
                                    .Distinct()
                                    .ToListAsync();

        return Ok(organizers);
    }

    [AllowAnonymous]
    [HttpGet("getTags")]
    public async Task<IActionResult> GetTags()
    {
        var tags = await Context.Tagovi
                                    .OrderBy(x => x.TagName)
                                    .Select(x => $"{x.TagName}")
                                    .ToListAsync();

        return Ok(tags);
    }

    [Authorize(Policy = "RequireVisitorRole")]
    [HttpGet("GetRecommendedEvents")]
    public async Task<IActionResult> GetRecommendedEvents()
    {

        var korisnik = await _userManager.Users
                                            .Include(x => x.Tagovi!)
                                            .ThenInclude(t => t.UserTag)
                                            .FirstOrDefaultAsync(x => x.Email == User.FindFirstValue(ClaimTypes.Email));

        //svi dogadjaji koji su u buducnosti
        List<Dogadjaj> dogadjaji = await Context.Dogadjaji
                                    .Include(x => x.Organizator)
                                    .Include(x => x.Tagovi)
                                    .Include(x => x.Rezervacije)
                                    .Include(x => x.RezervacijaProstora)
                                    .ThenInclude(x => x!.Prostor)
                                    .Where(x => x.Vreme > DateTime.Now && x.Status == StatusDogadjaja.Active)
                                    .ToListAsync();

        //posetio i rezervisao*
        var kojeJeKorisnikPosetio = await Context.Dogadjaji
                                    .Include(x => x.Organizator)
                                    .Include(x => x.Tagovi)
                                    .Include(x => x.RezervacijaProstora)
                                    .ThenInclude(x => x!.Prostor)
                                    .Include(x => x.Rezervacije)
                                    .Where(x => x.Rezervacije!.Any(y => y.Korisnik!.Id == korisnik!.Id))
                                    .ToListAsync();

        List<FullEventDto> povratniDogadjaji = new List<FullEventDto>();
        List<FullEventForRecomm> zaRejtovanje = new List<FullEventForRecomm>();

        List<string> output = new List<string>(); //da bi se videla logika ocenjivanja

        //za svaki dogadjaj kako se skalira rejt:
        //1: pogadjanje u tagovima korisnika - max 10
        //2: izvlacenje ocene na osnovu broja rezervacija - max 10
        //3: pogadjanje u tagovima dogadjaja sa dogadjajima koje je posetio - max 10 za sve koje je posetio
        //4: pogadjanje u lokaciji sa dogadjajima koje je posetio - max 10 za sve koje je posetio
        foreach (var dogadjaj in dogadjaji)
        {

            output.Add($"Logika za ocenjivanja za dogadjaj {dogadjaj.Naziv}");
            output.Add("Na pocetku se radi uporedjivanje tagova dogadjaja u iteraciji sa tagovima korisnika");
            double rejt = 0;

            //max je 10
            //pogadjanja u tagovima korisnika
            if (korisnik!.Tagovi != null && dogadjaj.Tagovi != null)
            {
                foreach (var tag in korisnik.Tagovi)
                {
                    foreach (var tag2 in dogadjaj.Tagovi)
                    {
                        var distance = HomePageUtils.LevenshteinDistance(tag.UserTag!.TagName, tag2.TagName);
                        string message = $"Lavenshtein distance za {tag.UserTag.TagName} i {tag2.TagName} je {distance} za {dogadjaj.Naziv}";
                        output.Add(message); 
                        if (distance < 3)
                        {
                            rejt += 1;
                        }
                    }
                }
                output.Add($"rejting za {dogadjaj.Naziv} je {rejt}"); 
            }

            rejt = rejt > 10 ? 10 : rejt;

            //max je 10 za rezervacije
            //izvlacenje ocene na osnovu broja rezervacija

            int rezervisanaMesta = 0;
            if (dogadjaj.Rezervacije != null)
                rezervisanaMesta = dogadjaj.Rezervacije!.Sum(rezervacija => rezervacija.BrojMesta);

            double rejtOdRezervacije = HomePageUtils.CalculateScoreReservation(rezervisanaMesta, 8);

            rejt += rejtOdRezervacije; // znaci kad je manje 8 mesta rezervisano, rejt opada linearno
            output.Add($"Za dogadjaj {dogadjaj.Naziv} je rezervisano {rezervisanaMesta} mesta, od rezervacije je rejt {rejtOdRezervacije}, a rejt je sad {rejt}"); 

            output.Add($"Uporedjujemo trenutni dogadjaj u iteraciji  {dogadjaj.Naziv} sa svim dogadjajima koje je korisnik posetio ili rezervisao* i za svaki skaliramo u odnosu na broj posecenih/rezervisanih korisnikovih");
            if (kojeJeKorisnikPosetio != null && kojeJeKorisnikPosetio.Count > 0)
            {
                foreach (var posetio in kojeJeKorisnikPosetio)
                {
                    output.Add($"Dogadjaj koji je korisnik posetio/rezervisao: {posetio.Naziv}");

                    if (posetio.ID == dogadjaj.ID)
                        continue;

                    double tempRejt = 0;
                    //max je 
                    //pogadjanje u tagovima
                    if (posetio.Tagovi != null && dogadjaj.Tagovi != null)
                    {
                        foreach (var tag in posetio.Tagovi)
                        {
                            foreach (var tag2 in dogadjaj.Tagovi)
                            {
                                if (HomePageUtils.LevenshteinDistance(tag.TagName, tag2.TagName) < 3)
                                    tempRejt += 1;
                                output.Add($"Lavenshtein distance izmedju  {tag.TagName} (posecen/rezervisan) i {tag2.TagName} (dogadjaj) trenutni dogadjaj {dogadjaj.Naziv} je {HomePageUtils.LevenshteinDistance(tag.TagName, tag2.TagName)}");
                            }
                        }
                    }
                    output.Add($"temp rejting za {dogadjaj.Naziv}  i {posetio.Naziv} je {tempRejt} za sad");
                    
                    tempRejt = tempRejt > 10 ? 10 : tempRejt;

                    //max je 10 za udaljenost
                    //pogadjanje u lokaciji
                    double dogadjajLat = dogadjaj.RezervacijaProstora!.Prostor!.Latitude;
                    double dogadjajLongt = dogadjaj.RezervacijaProstora.Prostor.Longitude;
                    double distance = HomePageUtils.HaversineDistance(posetio.RezervacijaProstora!.Prostor!.Latitude, posetio.RezervacijaProstora.Prostor.Longitude, dogadjajLat, dogadjajLongt) / 1000; // da bude u km
                    output.Add($" Physical distance between {posetio.Naziv} (posecen) and {dogadjaj.Naziv} (dogadjaj) is {distance} and score is {HomePageUtils.CalculateScoreDistance(distance, 300)}");
                    tempRejt += HomePageUtils.CalculateScoreDistance(distance, 300); // znaci kad dalje od 300km, rejt je 0

                    rejt += tempRejt / kojeJeKorisnikPosetio.Count;
                    output.Add($"tempRejt: {tempRejt}, skaliran: {tempRejt / kojeJeKorisnikPosetio.Count} ");
                }
            }

            output.Add($"Finalni score za {dogadjaj.Naziv} je {rejt}");
            zaRejtovanje.Add(new FullEventForRecomm
            {
                ID = dogadjaj.ID,
                Naziv = dogadjaj.Naziv,
                Slika = dogadjaj.Slika,
                Datum = dogadjaj.Vreme.ToString("dd.MM.yyyy."),
                Vreme = dogadjaj.Vreme.ToString("HH:mm"),
                Lokacija = dogadjaj?.RezervacijaProstora?.Prostor != null
                ? $"{dogadjaj.RezervacijaProstora.Prostor.Grad}, {dogadjaj.RezervacijaProstora.Prostor.Drzava}"
                : "Location not available",
                OrganizatorID = dogadjaj!.Organizator!.Id.ToString(),
                Organizator = $"{dogadjaj.Organizator!.Ime} {dogadjaj.Organizator!.Prezime}",
                Rating = rejt
            });

            output.Add("-------------------------------------------------");

        }

        zaRejtovanje = zaRejtovanje.OrderByDescending(x => x.Rating).Take(10).ToList();

        foreach (var dogadjaj in zaRejtovanje)
        {
            povratniDogadjaji.Add(new FullEventDto
            {
                ID = dogadjaj.ID,
                Naziv = dogadjaj.Naziv,
                Slika = dogadjaj.Slika,
                Datum = dogadjaj.Datum,
                Vreme = dogadjaj.Vreme,
                Lokacija = dogadjaj.Lokacija,
                OrganizatorID = dogadjaj.OrganizatorID,
                Organizator = dogadjaj.Organizator
            });
        }

        return Ok(povratniDogadjaji); // ovo se vraca inace
        //return Ok(new { output = output, zaRejtovanje });//ovo je za test
    }

}
