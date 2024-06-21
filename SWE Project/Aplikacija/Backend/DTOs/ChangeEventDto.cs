namespace Backend.DTOs;

public class ChangeEventDto
{
    [Required]
    [JsonPropertyName("id")]
    public int ID { get; set; }

    [Required]
    [JsonPropertyName("eventName")]
    public required string Naziv { get; set; }

    [Required]
    [JsonPropertyName("description")]
    public required string Opis { get; set; }

    [Required]
    [JsonPropertyName("tags")]
    public List<string>? Tagovi { get; set; }

    [Required]
    [JsonPropertyName("date")]
    public required string Datum { get; set; }

    [Required]
    [JsonPropertyName("time")]
    public required string Vreme { get; set; }

    [JsonPropertyName("video")]
    public string? Video { get; set; }
}
