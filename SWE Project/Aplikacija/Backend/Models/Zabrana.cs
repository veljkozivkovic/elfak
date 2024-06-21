namespace Backend.Models;

public class Zabrana
{
    public int Id { get; set; }
    public DateTime DatumOd { get; set; }
    public DateTime DatumDo { get; set; }
    public string? Razlog { get; set; }
    public Korisnik? Korisnik { get; set; }
}