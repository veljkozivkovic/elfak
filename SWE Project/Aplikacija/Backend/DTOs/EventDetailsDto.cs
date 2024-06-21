namespace Backend.DTOs;

public class EventDetailsDto
{
    [Required]
    [JsonPropertyName("description")]
    public required string Opis { get; set; }

    [Required]
    [Range(-90, 90)]
    [JsonPropertyName("latitude")]
    public double Latitude { get; set; }

    [Required]
    [Range(-180, 180)]
    [JsonPropertyName("longitude")]
    public double Longitude { get; set; }
}
