namespace Backend.DTOs;

public class BanUserDto
{
    [Required]
    [JsonPropertyName("userId")]
    public required string KorisnikId { get; set; }

    [Required]
    [JsonPropertyName("timeFrom")]
    public DateTime DatumOd { get; set; } = DateTime.Now;

    [Required]
    [JsonPropertyName("timeTo")]
    public required string DatumDo { get; set; }

    [Required]
    [JsonPropertyName("reason")]
    public required string Razlog { get; set; }
}