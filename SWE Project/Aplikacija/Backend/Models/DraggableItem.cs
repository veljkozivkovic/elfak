namespace Backend.Models;

public class DraggableItem
{
    [Key]
    public int ID { get; set; }
    public required string FrontID { get; set; }
    public TipItema Tip { get; set; }
    public double Top { get; set; }
    public double Left { get; set; }
    public double Height { get; set; }
    public double HeightFactor { get; set; }
    public int? BrojMesta { get; set; }
    public bool? Reserved { get; set; }
    public int? Price { get; set; }
    public PlanProstora? PlanProstora { get; set; }
    public Rezervacija? Rezervacija { get; set; }
}