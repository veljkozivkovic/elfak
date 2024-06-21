namespace Backend.Models;

public class UserTag
{
    [Key]
    [MaxLength(50)]
    public required string TagName { get; set; }
    public List<KorisnikTagovi>? Korisnici { get; set; }
}