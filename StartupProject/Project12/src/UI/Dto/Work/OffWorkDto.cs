using E=UI.Entity.Concrete.Employee;

namespace UI.Dto.Work;


public class OffWorkDto : FixDto {
    public Guid EmployeeId { get; set; }
    public string? EmployeeFullName { get; set; }
    public DateTime OffStart { get; set; }
    public DateTime OffEnd { get; set; }
    public int TotalDayCount { get; set; }
    public int TotalWeekdayCount { get; set; }
    public bool IsApproved { get; set; }
    public E::Employee Employee { get; set; } = null!;
}
