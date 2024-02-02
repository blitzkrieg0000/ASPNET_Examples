namespace Domain.Entities.Auth;


public class ApplicationUserRole : BaseEntity {
    public Guid UserId { get; set; }
    public Guid RoleId { get; set; }

    public virtual ApplicationRole Role { get; set; } = null!;
    public virtual ApplicationUser User { get; set; } = null!;
}
