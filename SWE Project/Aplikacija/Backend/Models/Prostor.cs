namespace Backend.Models;

public class Prostor
{
    [Key]
    public int ID { get; set; }

    [MaxLength(50)]
    public required string Grad { get; set; }

    [MaxLength(50)]
    public required string Drzava { get; set; }

    [MaxLength(200)]
    public required string Adresa { get; set; }

    [Range(-90, 90)]
    public required double Latitude { get; set; }

    [Range(-180, 180)]
    public required double Longitude { get; set; }

    public List<PlanProstora>? PlanoviProstora { get; set; }

    public List<RezervacijaProstora>? Rezervacije { get; set; }

    public Korisnik? VlasnikProstora { get; set; }
}