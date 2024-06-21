namespace Backend.DTOs;

public class ChangeUserDto
{

    [JsonPropertyName("currentPassword")]
    public string? CurrentPassword { get; set; }

    [JsonPropertyName("newPassword")]
    public string? NewPassword { get; set; }

    [Required]
    [JsonPropertyName("firstName")]
    public required string Ime { get; set; }

    [Required]
    [JsonPropertyName("lastName")]
    public required string Prezime { get; set; }

    [Required]
    [JsonPropertyName("phoneNumber")]
    public required string Telefon { get; set; }

    [Required]
    [JsonPropertyName("birthday")]
    public required string DatumRodjenja { get; set; }

    [JsonPropertyName("address")]
    public string? Adresa { get; set; }

    [JsonPropertyName("city")]
    public string? Grad { get; set; }
}