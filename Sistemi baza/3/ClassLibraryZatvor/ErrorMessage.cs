using System.Diagnostics.CodeAnalysis;

namespace ClassLibraryZatvor;

public class ErrorMessage
{
    public required int StatusCode { get; set; }
    public required string Message { get; set; }

    [SetsRequiredMembers]
    public ErrorMessage(string message, int statusCode = 400)
    {
        StatusCode = statusCode;
        Message = message;
    }
}
