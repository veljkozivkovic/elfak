namespace Backend.DTOs;

public class DraggableItemDto
{

    [JsonPropertyName("realId")]
    public int ID { get; set; }

    [Required]
    [JsonPropertyName("id")]
    public required string FrontID { get; set; }

    [Required]
    [JsonPropertyName("type")]
    public required string Tip { get; set; }

    [Required]
    [JsonPropertyName("top")]
    public double Top { get; set; }

    [Required]
    [JsonPropertyName("left")]
    public double Left { get; set; }

    [Required]
    [JsonPropertyName("height")]
    public double Height { get; set; }

    [Required]
    [JsonPropertyName("heightFactor")]
    public double HeightFactor { get; set; }

    [JsonPropertyName("numberOfSeats")]
    public int? BrojMesta { get; set; }

    [JsonPropertyName("reserved")]
    public bool? Reserved { get; set; }

    [JsonPropertyName("price")]
    public int? Price { get; set; }

    [JsonPropertyName("reservationId")]
    public int? ReservationId { get; set; }

    [JsonPropertyName("reservedSeats")]
    public int? ReservedSeats { get; set; }
}