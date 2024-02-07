namespace Domain.Entities.Auth;


public class ApplicationRole : BaseEntity {
    public string? Name { get; set; }

    public virtual ICollection<ApplicationUserRole> ApplicationUserRoles { get; set; }

    public ApplicationRole() {
        ApplicationUserRoles = new HashSet<ApplicationUserRole>();
    }

}
