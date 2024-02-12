using Microsoft.AspNetCore.Authorization;
using UI.Const.Auth;

namespace UI.Attribute;


public class RolesAttribute : AuthorizeAttribute {
    public RolesAttribute(params string[] roles) {
        _ = roles.Append(AuthRoleDefaults.SuperUser).Append(AuthRoleDefaults.Admin);
        Roles = String.Join(",", roles);
    }
}