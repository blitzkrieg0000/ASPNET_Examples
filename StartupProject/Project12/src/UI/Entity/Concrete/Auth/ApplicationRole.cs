
using UI.Entity;
using UI.Entity.Concrete.Employee;

namespace UI.Entities.Auth;


public class ApplicationRole : BaseEntity {
    public string? Name { get; set; }

    public virtual ICollection<ApplicationUserRole> ApplicationUserRoles { get; set; }
    public virtual ICollection<EmployeeType> EmployeeTypes { get; set; }
    public ApplicationRole() {
        ApplicationUserRoles = new HashSet<ApplicationUserRole>();
        EmployeeTypes = new HashSet<EmployeeType>();
    }

}
