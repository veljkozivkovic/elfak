namespace Backend.Models;

public class PlanProstora
{
    [Key]
    public int ID { get; set; }

    public int Kapacitet { get; set; }

    public List<DraggableItem>? DraggableItems { get; set; }

    public List<Line>? Lines { get; set; }

    public Prostor? Prostor { get; set; }
    public SurfaceDimension? SurfaceDimension { get; set; }

    [ForeignKey("DogadjajFK")]
    public Dogadjaj? Dogadjaj { get; set; }

}