namespace Backend.DTOs;

public class RegisterDto
{
    [Required]
    [EmailAddress]
    [JsonPropertyName("email")]
    public required string Email { get; set; }

    [Required]
    [JsonPropertyName("password")]
    public required string Password { get; set; }

    [Required]
    [JsonPropertyName("userType")]
    public required string UserType { get; set; }

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

    [JsonPropertyName("avatar")]
    public string? Slika { get; set; }

    [JsonPropertyName("address")]
    public string? Adresa { get; set; }

    [JsonPropertyName("city")]
    public string? Grad { get; set; }
}