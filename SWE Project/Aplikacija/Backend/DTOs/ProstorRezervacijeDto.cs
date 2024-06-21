namespace Backend.DTOs;

public class ProstorRezervacijeDto
{
    [JsonPropertyName("id")]
    public int ID { get; set; }
    [JsonPropertyName("eventName")]
    public required string NazivDogadjaja { get; set; }
    [JsonPropertyName("address")]
    public required string Adresa { get; set; }
    [JsonPropertyName("startTime")]
    public DateTime VremeOd { get; set; }
    [JsonPropertyName("endTime")]
    public DateTime VremeDo { get; set; }
    [JsonPropertyName("status")]
    public required string Status { get; set; }
}