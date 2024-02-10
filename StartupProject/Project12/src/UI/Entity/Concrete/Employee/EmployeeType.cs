using UI.Const.Auth;
using UI.Entities.Auth;

namespace UI.Entity.Concrete.Employee;


public class EmployeeType : BaseEntity {
    public string Name { get; set; }
    public virtual Guid ApplicationRoleId { get; set; } = RoleDefaults.Member.Id;

    public virtual ApplicationRole ApplicationRole { get; set; }
    public virtual ICollection<Employee> Employees { get; set; }

    public  EmployeeType() {
        Employees = new HashSet<Employee>();
    }
}
