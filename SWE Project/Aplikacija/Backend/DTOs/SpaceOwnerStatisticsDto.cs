namespace Backend.DTOs;

public class SpaceOwnerStatisticsDto
{
    [JsonPropertyName("rentableSpaces")]
    public int RentableSpaces { get; set; }
    [JsonPropertyName("totalRents")]
    public int TotalRents { get; set; }
}