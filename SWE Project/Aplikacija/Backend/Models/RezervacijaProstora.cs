namespace Backend.Models;

public class RezervacijaProstora
{
    [Key]
    public int ID { get; set; }

    public DateTime VremeOd { get; set; }

    public DateTime VremeDo { get; set; }

    public StatusRezervacije Status { get; set; }

    public Dogadjaj? Dogadjaj { get; set; }

    public Prostor? Prostor { get; set; }
}