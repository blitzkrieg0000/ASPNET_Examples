using UI.Entity;
using UI.Entity.Concrete.Employee;

namespace UI.Entities.Auth;


public class ApplicationUser : BaseEntity {
    public string Username { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Password { get; set; }

    public virtual ICollection<ApplicationUserRole> ApplicationUserRoles { get; set; }
    public virtual Employee? Employee { get; set; }

    public ApplicationUser() {
        ApplicationUserRoles = new HashSet<ApplicationUserRole>();
    }

}
