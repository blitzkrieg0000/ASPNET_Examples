namespace Application.Dtos.Auth;


public class UserSignUpDto : FixDto {
    public string? Username { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Password { get; set; }
    public bool? Gender { get; set; }
    public string? Description { get; set; }
}
