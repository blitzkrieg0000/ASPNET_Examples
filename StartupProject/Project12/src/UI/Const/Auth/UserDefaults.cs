namespace Application.Consts;


public readonly struct User {
    public readonly string Name;
    public readonly string Username;
    public readonly string Password;
    public readonly string Email;

    public User(string name, string username, string password, string email = "") {
        Name = name;
        Username = username;
        Password = password;
        Email = email;
    }
}


public readonly struct UserDefaults {

    public readonly struct Users {
        public static readonly User SuperUser = new(
            "root",
            "root",
            "f3f5e898ed41cd8e0b3785bc5bba537deffe3889e525b30e72f947a27c2d2caf986f73663a308e97ba6f24323ce2929e6afe4b86204d93617c16000dd574a8e5",
            "burakhansamli0.0.0.0@gmail.com"
        );
        public static readonly User Admin = new(
            "admin",
            "admin",
            "99ec526fe3e3f956acb4712b6bca88d918a3eb6d3e0a17634667e2775aad07ec1f8f84f8bbbf227eb5e0574177b13c8c30cc71b2d8e9bda722c023a81b754601"
        );
    }

    public readonly struct ClaimsTypes {
        public static readonly string ProfilePhoto = "ProfilePhoto";
        public static readonly string UserId = "UserId";
        public static readonly string UserAssignedEndpoints = "UserAssignedEndpoints";
    }

}
