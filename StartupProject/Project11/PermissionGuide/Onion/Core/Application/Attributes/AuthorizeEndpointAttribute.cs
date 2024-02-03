using Application.Enums;

namespace Application.Attributes;


public class AuthorizeEndpointAttribute : Attribute {
    private string identifier;
    public object Identifier {
        get {
            return identifier;
        }
        set {
            identifier = $"{value.GetType().FullName}+{value.GetType().GetEnumName(value)}";
        }
    }
    public string Menu { get; set; }
    public ActionType ActionType { get; set; }
    public string Definition { get; set; }
}
