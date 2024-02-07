namespace Domain.Entities.Auth;


public class ApplicationUserClaim : BaseEntity {
    public Guid UserId { get; set; }
    public string? ClaimType { get; set; }
    public string? ClaimValue { get; set; }

    public virtual ApplicationUser User { get; set; } = null!;
}