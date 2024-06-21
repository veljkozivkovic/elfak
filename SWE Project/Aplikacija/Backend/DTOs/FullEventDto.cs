namespace Backend.DTOs;

public class FullEventDto
{
    [Required]
    [JsonPropertyName("id")]
    public int ID { get; set; }

    [Required]
    [JsonPropertyName("img")]
    public required string Slika { get; set; }

    [Required]
    [JsonPropertyName("title")]
    public required string Naziv { get; set; }

    [Required]
    [JsonPropertyName("location")]
    public required string Lokacija { get; set; }

    [Required]
    [JsonPropertyName("date")]
    public required string Datum { get; set; }

    [Required]
    [JsonPropertyName("time")]
    public required string Vreme { get; set; }

    [Required]
    [JsonPropertyName("organizerID")]
    public required string OrganizatorID { get; set; }

    [Required]
    [JsonPropertyName("organizer")]
    public required string Organizator { get; set; }

}