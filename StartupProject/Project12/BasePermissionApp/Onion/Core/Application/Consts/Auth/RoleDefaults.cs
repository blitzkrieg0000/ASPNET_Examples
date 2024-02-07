namespace Application.Consts.Auth;


public readonly struct Role(string name, string id) {
    public readonly Guid Id = Guid.Parse(id);
    public readonly string Name = name;
}


public readonly struct RoleDefaults {
    //Class'a ihtiyacımız yok, gereksinimlerimizi struct karşılıyor. Readonly ile değiştirilmesinin önüne geçtik.
    public static readonly Role SuperUser = new("SuperUser", "00000000-0000-0000-0000-000000000001");
    public static readonly Role Admin = new("Admin", "00000000-0000-0000-0000-000000000002");
    public static readonly Role Member = new("Member", "00000000-0000-0000-0000-000000000003");
}


public static class RoleGroupDefaults {
    // Attribute elemanları Const olmalıdır. Bu yüzden struct kullanmadık.
    public const string AdminGroup = "AdminGroup";
    public const string MemberGroup = "MemberGroup";
}