using Application.Dtos.UserRole;
using Microsoft.AspNetCore.Http;

namespace Application.Dtos.User;


public class UserUpdateDto : UpdateDto {
    public string? Name { get; set; }
    public string? NormalizedName { get; set; }
    public string? Username { get; set; }
    public string? Email { get; set; }
    public bool EmailApproved { get; set; }
    public string? PhoneNumber { get; set; }
    public bool PhoneNumberApproved { get; set; }
    public string? Gender { get; set; }
    public string? Description { get; set; }
    public bool TwoFactorEnabled { get; set; }
    public DateTime LockoutEndDateUtc { get; set; }
    public bool LockoutEnabled { get; set; }
    public string? Image { get; set; }
    public IFormFileCollection? Files { get; set; }
}
