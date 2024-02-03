namespace Application.Consts;


public readonly struct Page {
    public readonly string Controller;
    public readonly string Action;
    public Page(string controller, string action = "Index") {
        Controller = controller;
        Action = action;
    }
}


public static class SignInDefaults {
    public static class RedirectionPages {
        public static readonly Page AdminPage = new("Admin", "Index");
        public static readonly Page MemberPage = new("Member", "Index");
        public static readonly Page HomePage = new("Home", "Index");
    }

}
