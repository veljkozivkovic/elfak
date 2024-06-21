namespace Backend.Models;

public class Line
{
    [Key]
    public int ID { get; set; }

    public double X1 { get; set; }

    public double X2 { get; set; }

    public double Y1 { get; set; }

    public double Y2 { get; set; }

    public PlanProstora? PlanProstora { get; set; }
}