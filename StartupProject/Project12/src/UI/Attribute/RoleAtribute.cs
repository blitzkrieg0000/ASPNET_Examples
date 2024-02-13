using Microsoft.AspNetCore.Authorization;
using UI.Const.Auth;

namespace UI.Attribute;


public class RolesAttribute : AuthorizeAttribute {
    public RolesAttribute(params string[] roles) {
        var r = roles.ToList();
        r.Add(AuthRoleDefaults.SuperUser);
        r.Add(AuthRoleDefaults.Admin);
        Roles = String.Join(",", r);
    }
}