using E=UI.Entity.Concrete.Employee;

namespace UI.Entity.Concrete.Work;


public class OffWork : BaseEntity {
    public Guid EmployeeId { get; set; }
    public DateTime OffStart { get; set; }
    public DateTime OffEnd { get; set; }
    public int MyProperty { get; set; }
    public bool IsApproved { get; set; }
    public E::Employee Employee { get; set; } = null!;
}
