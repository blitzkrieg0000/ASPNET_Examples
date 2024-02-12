using Microsoft.AspNetCore.Razor.TagHelpers;
using UI.Const.Auth;
using UI.Extension;

namespace UI.TagHelpers.HasPermission;


[HtmlTargetElement("RolePermission")]
public class RolePermissionTagHelper : TagHelper {
    public Role[] Role { get; set; }
    private readonly IHttpContextAccessor _httpContextAccessor;

    public RolePermissionTagHelper(IHttpContextAccessor httpContextAccessor) {
        _httpContextAccessor = httpContextAccessor;
    }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output) {
        if (!(bool)_httpContextAccessor.HttpContext?.User.HasRoleAny(Role)) {
            output.SuppressOutput();
        }
    }

}
