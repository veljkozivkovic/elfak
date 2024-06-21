namespace Backend.DTOs;

public class DogadjajDto
{

    [Required]
    [JsonPropertyName("id")]
    public int ID { get; set; }

    [Required]
    [JsonPropertyName("name")]
    public required string Naziv { get; set; }

    [Required]
    [JsonPropertyName("date")]
    public DateTime Datum { get; set; }

    [Required]
    [JsonPropertyName("image")]
    public required string Slika { get; set; }
}
