namespace Backend.Models;

public class KorisnikTagovi
{
    [Key]
    public int ID { get; set; }
    public Korisnik? Korisnik { get; set; }
    public UserTag? UserTag { get; set; }
}