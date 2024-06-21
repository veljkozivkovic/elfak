namespace Backend.Services;

public class TokenService
{
    private readonly IConfiguration _config;
    private readonly UserManager<Korisnik> _userManager;

    public TokenService(IConfiguration config, UserManager<Korisnik> userManager)
    {
        _userManager = userManager;
        _config = config;
    }

    public async Task<string> CreateToken(Korisnik korisnik)
    {
        var claims = new List<Claim>();

        claims.Add(new Claim(ClaimTypes.NameIdentifier, korisnik.Id.ToString()));

        if (!string.IsNullOrEmpty(korisnik.Email))
        {
            claims.Add(new Claim(ClaimTypes.Email, korisnik.Email));
        }

        var roles = await _userManager.GetRolesAsync(korisnik);

        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtSettings:TokenKey"]!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = creds
        };

        var tokenHandler = new JwtSecurityTokenHandler();

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}