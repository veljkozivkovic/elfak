namespace Backend.Models;

public class VisitorRank
{
    [Key]
    public int ID { get; set; }
    public required string RankName { get; set; }
    public int Points { get; set; }
    public List<Korisnik>? Korisnik { get; set; }
}