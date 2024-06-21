namespace Backend.DTOs;

public class SpaceBasicDto
{
    [Required]
    [JsonPropertyName("id")]
    public int ID { get; set; }

    [Required]
    [JsonPropertyName("city")]
    public required string Grad { get; set; }

    [Required]
    [JsonPropertyName("country")]
    public required string Drzava { get; set; }

    [Required]
    [JsonPropertyName("address")]
    public required string Adresa { get; set; }

    [Required]
    [JsonPropertyName("capacity")]
    public required int Kapacitet { get; set; }
}