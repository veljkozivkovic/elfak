namespace ClassLibraryZatvor;

internal static class Extensions
{
    internal static string HandleError(this Exception e)
    {
        StringBuilder sb = new();

        sb.AppendLine($"({e.GetType().Name}):");
        sb.Append($"{e.Message}");
        int indent = 4;

        Exception? exception = e.InnerException;

        while (exception != null)
        {
            sb.AppendLine($"{new string(' ', indent)}-> ({e.GetType().Name}):");
            sb.Append($"{exception.Message}");
            indent += 4;
            exception = exception.InnerException;
        }

        string errorText = sb.ToString();

        Console.ForegroundColor = ConsoleColor.Red;
        Console.Error.WriteLine(errorText);
        Console.ResetColor();
        return errorText;
    }

    internal static ErrorMessage ToError(this string message, int statusCode = 400)
    {
        return new ErrorMessage(message, statusCode);
    }

    internal static ErrorMessage GetError(string message, int statusCode = 400)
    {
        return new ErrorMessage(message, statusCode);
    }
}
