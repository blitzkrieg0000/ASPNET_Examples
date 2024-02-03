using System.Text.Json;

namespace Application.Extensions;


public static class StringJsonExtension {
    public static string JsonSerialize<T>(this T model) {
        return JsonSerializer.Serialize(model);
    }

    public static T? JsonDeserialize<T>(this string context) {
        return JsonSerializer.Deserialize<T>(context);
    }
}
