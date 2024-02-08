namespace Domain.Entities.Auth;


public class ApplicationRoleMenu : BaseEntity {
    public Guid RoleId { get; set; }
    public Guid MenuId { get; set; }

    public virtual ApplicationRole Role { get; set; } = null!;
    public virtual ApplicationMenu Menu { get; set; } = null!;
}

