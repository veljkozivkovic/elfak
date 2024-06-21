namespace Backend.DTOs;

public class EventForListDto
{
    [JsonPropertyName("id")]
    public int ID { get; set; }

    [JsonPropertyName("name")]
    public required string Naziv { get; set; }

    [JsonPropertyName("image")]
    public required string Slika { get; set; }

    [JsonPropertyName("date")]
    public required DateTime Datum { get; set; }
}