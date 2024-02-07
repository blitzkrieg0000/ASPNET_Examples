namespace Domain.Entities.Auth;


public class ApplicationUserLogin : BaseEntity {
    public Guid UserId { get; set; }
    public string? LoginProvider { get; set; }
    public string? ProviderKey { get; set; }

    public virtual ApplicationUser User { get; set; } = null!;
}
