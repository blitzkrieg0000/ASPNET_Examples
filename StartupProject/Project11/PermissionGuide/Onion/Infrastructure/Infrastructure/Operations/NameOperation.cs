using System.Text.RegularExpressions;

namespace Infrastructure.Operations;


public static class NameOperation {
    public static string CharacterRegulatory(string name) {
        name = Regex.Replace(name, @"[^\u0020-\u007E]", "");
        name = Regex.Replace(name, @"[^a-zA-Z\d\s:]", "");
        name = name.Replace(" ", "_");
        name = name.Length == 0 ? "temp" : name;
        return name;
    }
}
