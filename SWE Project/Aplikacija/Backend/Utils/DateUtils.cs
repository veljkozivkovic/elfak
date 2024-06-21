namespace Backend.Utils;

public static class DateUtils
{
    public static string TimeAgo(DateTime dateTime)
    {
        var timeSpan = DateTime.Now - dateTime;

        if (timeSpan.TotalSeconds < 60)
        {
            if (timeSpan.Seconds == 0)
                return "Just now";
            else if (timeSpan.Seconds == 1)
                return $"{timeSpan.Seconds} second ago";
            else
                return $"{timeSpan.Seconds} seconds ago";
        }
        else if (timeSpan.TotalMinutes < 60)
        {
            if (timeSpan.Minutes == 1)
                return $"{timeSpan.Minutes} minute ago";
            else
                return $"{timeSpan.Minutes} minutes ago";
        }
        else if (timeSpan.TotalHours < 24)
        {
            if (timeSpan.Hours == 1)
                return $"{timeSpan.Hours} hour ago";
            else
                return $"{timeSpan.Hours} hours ago";
        }
        else if (timeSpan.TotalDays < 30)
        {
            if (timeSpan.Days == 1)
                return $"{timeSpan.Days} day ago";
            else
                return $"{timeSpan.Days} days ago";
        }
        else if (timeSpan.TotalDays < 365)
        {
            int months = Convert.ToInt32(timeSpan.TotalDays / 30);
            if (months == 1)
                return $"{months} month ago";
            else
                return $"{months} months ago";
        }
        else
        {
            int years = Convert.ToInt32(timeSpan.TotalDays / 365);
            if (years == 1)
                return $"{years} year ago";
            else
                return $"{years} years ago";
        }
    }
}