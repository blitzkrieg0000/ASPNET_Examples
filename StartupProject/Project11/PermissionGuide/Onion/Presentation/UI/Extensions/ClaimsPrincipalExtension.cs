using System.Security.Claims;
using Application.Consts;
using Application.Consts.Auth;

namespace UI.Extensions;


public static class ClaimsPrincipalExtension {

    private static IEnumerable<Role> MatchRoles(ClaimsPrincipal principal, Role[] roles) {
        return roles
        .Where(x => principal.Claims
            .Where(c => c.Type == ClaimTypes.Role)
            .Select(c => c.Value)
            .Any(a => a == x.Name)
        );
    }


    public static bool IsRoot(this ClaimsPrincipal principal) => principal.Claims.Where(c => c.Type == ClaimTypes.Role).Any(c => c.Value == RoleDefaults.SuperUser.Name);

    [Obsolete("Tüm roller cookie'lerde claim olarak tutulduğunda cookie'yi şişirdiği için artık kullanılmayacak.")]
    public static bool HasRoleAll(this ClaimsPrincipal principal, params Role[] roles) {
        return IsRoot(principal) || MatchRoles(principal, roles).Count() == roles.Length;
    }

    [Obsolete("Tüm roller cookie'lerde claim olarak tutulduğunda cookie'yi şişirdiği için artık kullanılmayacak.")]
    public static bool HasRoleAny(this ClaimsPrincipal principal, params Role[] roles) {
        return IsRoot(principal) || MatchRoles(principal, roles).Any();
    }

    public static string[] GetAllRole(this ClaimsPrincipal principal) {
        return principal.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).ToArray();
    }

    // GET CLAIM
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
