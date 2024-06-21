namespace Backend.Models;

public class Tag
{
    [Key]
    [MaxLength(50)]
    public required string TagName { get; set; }
    public List<Dogadjaj>? Dogadjaji { get; set; }
}