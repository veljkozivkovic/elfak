namespace Backend.DTOs
{
    public class CreateEventDto
    {
        [Required]
        [JsonPropertyName("eventName")]
        public required string Naziv { get; set; }

        [Required]
        [JsonPropertyName("description")]
        public required string Opis { get; set; }

        [Required]
        [JsonPropertyName("date")]
        public required string Datum { get; set; }

        [Required]
        [JsonPropertyName("time")]
        public required string Vreme { get; set; }

        [Required]
        [JsonPropertyName("tags")]
        public List<string>? Tags { get; set; }

        [JsonPropertyName("video")]
        public string? Video { get; set; }

        [Required]
        [JsonPropertyName("spaceId")]
        public int ProstorId { get; set; }

        [Required]
        [JsonPropertyName("items")]
        public List<DraggableItemDto>? Items { get; set; }

        [Required]
        [JsonPropertyName("lines")]
        public List<LineDto>? Lines { get; set; }

        [Required]
        [JsonPropertyName("surfaceDimension")]
        public SurfaceDimensionDto? SurfaceDimension { get; set; }

    }
}