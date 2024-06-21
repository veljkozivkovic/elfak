namespace Backend.DTOs;

public class CommentDto
{
    [Required]
    [JsonPropertyName("eventId")]
    public int DogadjajId { get; set; }

    [Required]
    [JsonPropertyName("comment")]
    public required string Komentar { get; set; }

    [Required]
    [JsonPropertyName("rating")]
    public int Ocena { get; set; }
}