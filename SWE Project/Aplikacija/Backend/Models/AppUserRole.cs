namespace Backend.Models;

public class AppUserRole : IdentityUserRole<Guid>
{
    public Korisnik? Korisnik { get; set; }
    public AppRole? Role { get; set; }
}
