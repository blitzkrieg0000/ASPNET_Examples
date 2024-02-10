namespace UI.Dto.Work;


public class OffWork : FixDto {
    public Guid EmployeeId { get; set; }
    public DateTime OffStart { get; set; }
    public DateTime OffEnd { get; set; }
    public int MyProperty { get; set; }
    public bool IsApproved { get; set; }
}
