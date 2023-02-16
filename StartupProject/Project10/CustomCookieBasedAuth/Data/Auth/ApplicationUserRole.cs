namespace CustomCookieBasedAuth.Data.Auth;

public class ApplicationUserRole {
    public long UserId { get; set; }
    public long RoleId { get; set; }

    public virtual ApplicationRole Role { get; set; } = null!;
    public virtual ApplicationUser User { get; set; } = null!;
}
