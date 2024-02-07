using System.Security.Claims;
using Application.Consts;
using Application.Consts.Auth;

namespace UI.Extensions;


public static class ClaimsPrincipalExtension {

    public static bool IsRoot(this ClaimsPrincipal principal) => principal.Claims.Where(c => c.Type == ClaimTypes.Role).Any(c => c.Value == RoleDefaults.SuperUser.Name);


    public static string[] GetAllRole(this ClaimsPrincipal principal) {
        return principal.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).ToArray();
    }


    public static string? GetCurrentUserName(this ClaimsPrincipal principal) {
        return principal.Claims.Where(c => c.Type == ClaimTypes.Name).Select(c => c.Value).FirstOrDefault();
    }


    public static string? GetCurrentUserId(this ClaimsPrincipal principal) {
        return principal.Claims.Where(c => c.Type == UserDefaults.ClaimsTypes.UserId).Select(c => c.Value).FirstOrDefault();
    }


    public static string? GetCurrentUserPP(this ClaimsPrincipal principal) {
        return principal.Claims.Where(c => c.Type == UserDefaults.ClaimsTypes.ProfilePhoto).Select(c => c.Value).FirstOrDefault();
    }


}
