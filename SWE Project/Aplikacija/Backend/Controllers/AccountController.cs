namespace Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
    public Context Context { get; set; }
    private readonly UserManager<Korisnik> _userManager;
    private readonly TokenService _tokenService;

    public AccountController(UserManager<Korisnik> userManager, TokenService tokenService, Context context)
    {
        _tokenService = tokenService;
        _userManager = userManager;
        Context = context;
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<ActionResult<KorisnikDto>> Login([FromBody] LoginDto loginDto)
    {
        var korisnik = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == loginDto.Email);

        if (korisnik == null) return Unauthorized($"User with this email doesn't exist: {loginDto.Email}");

        var banned = await UserUtils.IsBanned(korisnik, Context);

        if (banned != null)
        {
            return Unauthorized($"You are banned from the platform until {banned.DatumDo.ToShortDateString()}. Reason: {banned.Razlog}");
        }

        var result = await _userManager.CheckPasswordAsync(korisnik, loginDto.Password);

        if (result)
        {
            var korisnikObject = await CreateUserObject(korisnik);
            return korisnikObject;
        }

        return Unauthorized("Password is incorrect. Please try again.");
    }

    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<ActionResult<KorisnikDto>> Register([FromBody] RegisterDto registerDto)
    {

        if (await _userManager.Users.AnyAsync(x => x.Email == registerDto.Email))
        {
            return ValidationProblem("Email is already in use.");
        }

        if (registerDto.UserType == "Admin")
        {
            registerDto.UserType = "Visitor";
        }

        var korisnik = new Korisnik
        {
            Ime = registerDto.Ime,
            Prezime = registerDto.Prezime,
            Email = registerDto.Email,
            UserName = registerDto.Email,
            Telefon = registerDto.Telefon,
            DatumRodjenja = DateTime.Parse(registerDto.DatumRodjenja),
            SlikaProfila = registerDto.Slika,
            Adresa = registerDto.Adresa,
            Grad = registerDto.Grad
        };

        var result = await _userManager.CreateAsync(korisnik, registerDto.Password);

        if (result.Succeeded)
        {
            var roleResult = await _userManager.AddToRoleAsync(korisnik, registerDto.UserType);
            if (!roleResult.Succeeded)
                return BadRequest(roleResult.Errors);
            var korisnikObject = await CreateUserObject(korisnik);
            return korisnikObject;
        }

        return BadRequest(result.Errors);
    }

    [Authorize]
    [HttpGet("getCurrentUser")]
    public async Task<ActionResult<KorisnikDto>> GetCurrentUser()
    {
        var korisnik = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == User.FindFirstValue(ClaimTypes.Email));

        var banned = await UserUtils.IsBanned(korisnik!, Context);

        if (banned != null)
        {
            return Unauthorized($"You are banned from the platform until {banned.DatumDo.ToShortDateString()}. Reason: {banned.Razlog}");
        }

        var korisnikObject = await CreateUserObject(korisnik!);
        return korisnikObject;
    }

    [Authorize]
    [HttpPut("updateUser")]
    public async Task<ActionResult<KorisnikDto>> UpdateUser([FromBody] ChangeUserDto changeUserDto)
    {
        var korisnik = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == User.FindFirstValue(ClaimTypes.Email));

        var banned = await UserUtils.IsBanned(korisnik!, Context);

        if (banned != null)
        {
            return Unauthorized($"You are banned from the platform until {banned.DatumDo.ToShortDateString()}. Reason: {banned.Razlog}");
        }

        korisnik!.Ime = changeUserDto.Ime;
        korisnik.Prezime = changeUserDto.Prezime;
        korisnik.Telefon = changeUserDto.Telefon;
        korisnik.DatumRodjenja = DateTime.Parse(changeUserDto.DatumRodjenja);
        korisnik.Adresa = changeUserDto.Adresa;
        korisnik.Grad = changeUserDto.Grad;

        if (!(String.IsNullOrEmpty(changeUserDto.CurrentPassword) && String.IsNullOrEmpty(changeUserDto.NewPassword)))
        {
            var passwordChangeResult = await _userManager.ChangePasswordAsync(korisnik, changeUserDto.CurrentPassword!, changeUserDto.NewPassword!);

            if (!passwordChangeResult.Succeeded)
            {
                return BadRequest(passwordChangeResult.Errors);
            }
        }

        var result = await _userManager.UpdateAsync(korisnik);

        if (result.Succeeded)
        {
            var korisnikObject = await CreateUserObject(korisnik);
            return korisnikObject;
        }

        return BadRequest(result.Errors);
    }

    private async Task<KorisnikDto> CreateUserObject(Korisnik korisnik)
    {
        return new KorisnikDto
        {
            FirstName = korisnik.Ime,
            LastName = korisnik.Prezime,
            Token = await _tokenService.CreateToken(korisnik),
            DateOfBirth = korisnik.DatumRodjenja,
            PhoneNumber = korisnik.Telefon,
            Avatar = korisnik.SlikaProfila,
            Address = korisnik.Adresa,
            City = korisnik.Grad
        };
    }
}