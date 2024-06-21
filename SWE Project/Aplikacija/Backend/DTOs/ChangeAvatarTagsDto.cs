namespace Backend.DTOs;

public class ChangeAvatarTagsDto
{
    [JsonPropertyName("avatar")]
    public string? Avatar { get; set; }

    [JsonPropertyName("tags")]
    public List<string>? Tags { get; set; }
}