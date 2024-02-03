namespace Application.Dtos.User;


public class UserDto : FixDto {
    public string? Name { get; set; }
    public string? NormalizedName { get; set; }
    public string? Username { get; set; }
    public string? Email { get; set; }
    public bool EmailApproved { get; set; }
    public string? PhoneNumber { get; set; }
    public bool PhoneNumberApproved { get; set; }
    public string? Password { get; set; }
    public string? Gender { get; set; }
    public string? Description { get; set; }
    public bool TwoFactorEnabled { get; set; }
    public DateTime LockoutEndDateUtc { get; set; }
    public bool LockoutEnabled { get; set; }
    public long AccessFailedCount { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenEndDate { get; set; }
    public DateTime SecurityStampDate { get; set; }
}

