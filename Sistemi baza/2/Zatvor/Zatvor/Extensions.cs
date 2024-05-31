namespace Zatvor;

public static class Extensions
{
    public static string FormatExceptionMessage(this Exception ex)
    {
        StringBuilder sb = new();
        Exception? temp = ex;
        int indent = 0;

        while (temp != null)
        {
            if (indent > 0)
            {
                sb.Append($"{'-'.Repeat(indent)}> ");
            }

            sb.AppendLine(temp.Message);
            indent += 2;
            temp = temp.InnerException;
        }

        return sb.ToString();
    }

    public static string Repeat(this char c, int count)
    {
        return new string(c, count);
    }

    public static string ToFormattedString(this object? obj)
    {

        if (obj == null)
        {
            return "null";
        }

        StringBuilder sb = new();
        var properties = obj.GetType().GetProperties();

        sb.AppendLine(obj.GetType().Name);
        sb.AppendLine("{");

        foreach (PropertyInfo property in properties)
        {
            object? propValue = property.GetValue(obj);

            if (IsSimpleType(property.PropertyType))
            {
                sb.AppendLine($"  {property.Name}: {propValue}");
            }
        }

        sb.AppendLine("}");

        return sb.ToString();
    }

    public static bool IsSimpleType(this Type type)
    {
        if (type.IsGenericType &&
            type.GetGenericTypeDefinition() == typeof(Nullable<>))
        {
            type = Nullable.GetUnderlyingType(type) ?? type;
        }

        return type.IsPrimitive ||
               type.IsEnum ||
               type.Equals(typeof(string)) ||
               type.Equals(typeof(decimal)) ||
               type.Equals(typeof(DateTime));
    }

}