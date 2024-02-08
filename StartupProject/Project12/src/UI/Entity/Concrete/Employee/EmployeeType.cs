namespace UI.Entity.Concrete.Employee;


public class EmployeeType : BaseEntity {
    public string Name { get; set; }

    public virtual ICollection<Employee> Employees { get; set; }

    public  EmployeeType() {
        Employees = new HashSet<Employee>();
    }
}
