namespace UI.Dto.Employee;


public class EmployeeDto : FixDto {
    public Guid EmployeeTypeId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Mail { get; set; }
    public string Phone { get; set; }
}
