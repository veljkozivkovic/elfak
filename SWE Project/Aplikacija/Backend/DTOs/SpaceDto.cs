namespace Backend.DTOs;

public class SpaceDto
{
    [JsonPropertyName("id")]
    public int ID { get; set; }

    [JsonPropertyName("items")]
    public List<DraggableItemDto>? DraggableItems { get; set; }

    [JsonPropertyName("lines")]
    public List<LineDto>? Lines { get; set; }

    [JsonPropertyName("surfaceDimension")]
    public SurfaceDimensionDto? SurfaceDimension { get; set; }

    [JsonPropertyName("description")]
    public string? Opis { get; set; }

    [JsonPropertyName("city")]
    public string? Grad { get; set; }

    [JsonPropertyName("country")]
    public string? Drzava { get; set; }

    [JsonPropertyName("address")]
    public string? Adresa { get; set; }

    [Range(-90, 90)]
    [JsonPropertyName("latitude")]
    public double Latitude { get; set; }

    [Range(-180, 180)]
    [JsonPropertyName("longitude")]
    public double Longitude { get; set; }

}