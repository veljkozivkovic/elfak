namespace Backend.Models;

public class Korisnik : IdentityUser<Guid>
{
    public required string Ime { get; set; }
    public required string Prezime { get; set; }
    public required string Telefon { get; set; }
    public DateTime DatumRodjenja { get; set; }
    public string? SlikaProfila { get; set; }
    public string? Adresa { get; set; }
    public string? Grad { get; set; }
    public AppUserRole? UserRole { get; set; }
    public List<Dogadjaj>? OrganizatorDogadjaji { get; set; }
    public List<Rezervacija>? Rezervacije { get; set; }
    public List<Prostor>? VlasnikProstori { get; set; }
    public List<Ocena>? Ocene { get; set; }
    public List<Zabrana>? KorisnikZabrane { get; set; }
    public List<KorisnikTagovi>? Tagovi { get; set; }
    public VisitorRank? VisitorRank { get; set; }
}