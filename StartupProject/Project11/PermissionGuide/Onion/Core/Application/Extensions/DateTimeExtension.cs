namespace Application.Extensions;

public static class DateTimeExtensions {
    public static string ToUnixTime(this DateTime dateTime) {
        DateTimeOffset dto = new(dateTime.ToUniversalTime());
        return dto.ToUnixTimeSeconds().ToString();
    }

    public static string ToUnixTimeMilliSeconds(this DateTime dateTime) {
        DateTimeOffset dto = new(dateTime.ToUniversalTime());
        return dto.ToUnixTimeMilliseconds().ToString();
    }

    public static string ToLocalTimeWithFormat(this DateTime dateTime, string format = "dd/MM/yyyy HH:mm:ss") {
        return dateTime.ToLocalTime().ToString(format);
    }
}