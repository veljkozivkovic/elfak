namespace Backend.Models;

public class Ocena
{
    [Key]
    public int ID { get; set; }
    [Range(1, 10)]
    public int Vrednost { get; set; }
    [MaxLength(200)]
    public string? Komentar { get; set; }
    public DateTime VremeKomentara { get; set; } = DateTime.Now;
    public Dogadjaj? Dogadjaj { get; set; }
    public Korisnik? Korisnik { get; set; }
}