namespace Backend.Models;

public class AppRole : IdentityRole<Guid>
{
    public ICollection<AppUserRole>? UserRoles { get; set; }
}