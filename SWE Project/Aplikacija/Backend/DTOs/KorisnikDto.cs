namespace Backend.DTOs;

public class KorisnikDto
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Token { get; set; }
    public required string PhoneNumber { get; set; }
    public required DateTime DateOfBirth { get; set; }
    public string? Avatar { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
}