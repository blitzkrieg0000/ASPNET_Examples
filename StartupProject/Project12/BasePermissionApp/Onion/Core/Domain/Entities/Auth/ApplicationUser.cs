namespace Domain.Entities.Auth;


public class ApplicationUser : BaseEntity {
    public string? Name { get; set; }
    public string? NormalizedName { get; set; }
    public string Username { get; set; }
    public string? Email { get; set; }
    public bool EmailApproved { get; set; }
    public string? PhoneNumber { get; set; }
    public bool PhoneNumberApproved { get; set; }
    public string? Password { get; set; }
    public string Gender { get; set; }
    public string? Description { get; set; }
    public bool TwoFactorEnabled { get; set; }
    public DateTime LockoutEndDateUtc { get; set; }
    public bool LockoutEnabled { get; set; }
    public long AccessFailedCount { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenEndDate { get; set; }
    public DateTime SecurityStampDate { get; set; } = DateTime.UtcNow;

    public virtual ICollection<ApplicationUserClaim> ApplicationUserClaims { get; set; }
    public virtual ICollection<ApplicationUserLogin> ApplicationUserLogins { get; set; }
    public virtual ICollection<ApplicationUserRole> ApplicationUserRoles { get; set; }

    public ApplicationUser() {
        ApplicationUserClaims = new HashSet<ApplicationUserClaim>();
        ApplicationUserLogins = new HashSet<ApplicationUserLogin>();
        ApplicationUserRoles = new HashSet<ApplicationUserRole>();
    }


}
