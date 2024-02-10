namespace UI.Const.Auth;


public readonly struct Role {
    public readonly Guid Id;
    public readonly string Name;

    public Role(string name, string id) {
        Id = Guid.Parse(id);
        Name = name;
    }
}


public static class AuthRoleDefaults {
    public const string SuperUser = "SuperUser";
    public const string Admin = "Admin";
    public const string Member = "Member";
    public const string Manager = "Manager";
    public const string IT = "IT";
    public const string HumanResources = "HumanResources";
    public const string Employee = "Employee";
}


//! EĞER ENDPOINTLER İLE ROL YETKİLENDİRME TANIMLAMAZSAK BU ŞEKİLDE ROLLERİ STATİK OLARAK AYARLARIZ.
//? EĞER ENDPOINTLER İLE ROL YETKİLENDİRME TANIMLAMAZSAK BU ŞEKİLDE ROLLERİ STATİK OLARAK AYARLARIZ.
//* EĞER ENDPOINTLER İLE ROL YETKİLENDİRME TANIMLAMAZSAK BU ŞEKİLDE ROLLERİ STATİK OLARAK AYARLARIZ.
public readonly struct RoleDefaults {
    //Class'a ihtiyacımız yok, gereksinimlerimizi struct karşılıyor. Readonly ile değiştirilmesinin önüne geçtik.
    public static readonly Role SuperUser = new(AuthRoleDefaults.SuperUser, "00000000-0000-0000-0000-000000000001");
    public static readonly Role Admin = new(AuthRoleDefaults.Admin, "00000000-0000-0000-0000-000000000002");
    public static readonly Role Member = new(AuthRoleDefaults.Member, "00000000-0000-0000-0000-000000000003");
    public static readonly Role Manager = new(AuthRoleDefaults.Manager, "00000000-0000-0000-0000-000000000004");
    public static readonly Role IT = new(AuthRoleDefaults.IT, "00000000-0000-0000-0000-000000000005");
    public static readonly Role HumanResources = new(AuthRoleDefaults.HumanResources, "00000000-0000-0000-0000-000000000006");
    public static readonly Role Employee = new(AuthRoleDefaults.Employee, "00000000-0000-0000-0000-000000000007");
}


public static class RoleGroupDefaults {
    // Attribute elemanları Const olmalıdır. Bu yüzden struct kullanmadık.
    public const string AdminGroup = "AdminGroup";
    public const string MemberGroup = "MemberGroup";
}