namespace Backend.Models;

public class SurfaceDimension
{
    [Key]
    public int ID { get; set; }
    public double Height { get; set; }
    public double Width { get; set; }
    [ForeignKey("PlanProstoraFK")]
    public PlanProstora? PlanProstora { get; set; }

}