namespace Application.Dtos.UserRole;


public class UserRoleAuthDto : FixDto {
    public string? UserName { get; set; }
    public string? RoleName { get; set; }
    public Guid UserId { get; set; }
    public Guid RoleId { get; set; }
    
}
