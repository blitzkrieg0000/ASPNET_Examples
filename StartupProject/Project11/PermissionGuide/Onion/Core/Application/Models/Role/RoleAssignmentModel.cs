namespace Application.Models.Role;


public class RoleAssignmentModel {
    public Guid UserId { get; set; }
    public Guid RoleId { get; set; }
    public string? Name { get; set; }
    public string? Avatar { get; set; }
    public string? Description { get; set; }
}
