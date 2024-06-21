namespace Backend.DTOs;

public class HTMLMailData
{
    public required string EmailToId { get; set; }
    public required string EmailToName { get; set; }
    public required string EmailSubject { get; set; }
    public required string EventName { get; set; }
    public required string EventDate { get; set; }
    public string? RescheduledDate { get; set; }
    public string? EventLocation { get; set; }
    public required string MailType { get; set; }
}