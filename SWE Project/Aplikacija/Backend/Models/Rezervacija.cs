namespace Backend.Models;

public class Rezervacija
{
    [Key]
    public int ID { get; set; }
    public DateTime VremeRezervacije { get; set; } = DateTime.Now;
    public int BrojMesta { get; set; }
    [ForeignKey("StoFK")]
    public DraggableItem? Sto { get; set; }
    public Dogadjaj? Dogadjaj { get; set; }
    public Korisnik? Korisnik { get; set; }
}