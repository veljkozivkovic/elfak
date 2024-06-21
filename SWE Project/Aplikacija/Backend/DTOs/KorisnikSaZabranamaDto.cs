namespace Backend.DTOs;

public class KorisnikSaZabranamaDto
{
    [JsonPropertyName("userId")]
    public string? KorisnikId { get; set; }
    [JsonPropertyName("banId")]
    public int ZabranaId { get; set; }
    [JsonPropertyName("firstName")]
    public string? Ime { get; set; }
    [JsonPropertyName("lastName")]
    public string? Prezime { get; set; }
    [JsonPropertyName("avatar")]
    public string? Avatar { get; set; }
    [JsonPropertyName("role")]
    public string? Role { get; set; }
    [JsonPropertyName("timeFrom")]
    public DateTime DatumOd { get; set; }
    [JsonPropertyName("timeTo")]
    public DateTime DatumDo { get; set; }
    [JsonPropertyName("reason")]
    public string? Razlog { get; set; }
}