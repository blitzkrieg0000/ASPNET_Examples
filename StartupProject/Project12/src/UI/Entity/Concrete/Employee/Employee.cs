using UI.Entities.Auth;
using UI.Entity.Concrete.Work;

namespace UI.Entity.Concrete.Employee;


public class Employee : BaseEntity {
    public Guid EmployeeTypeId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Mail { get; set; }
    public string Phone { get; set; }

    public virtual EmployeeType EmployeeType { get; set; } = null!;
    public virtual ICollection<OffWork> OffWorks { get; set; }
    public virtual ApplicationUser ApplicationUser { get; set; }
    
    public Employee() {
        OffWorks = new HashSet<OffWork>();
    }
}
