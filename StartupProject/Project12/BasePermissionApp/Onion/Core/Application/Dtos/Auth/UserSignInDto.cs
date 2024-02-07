namespace Application.Dtos.Auth;


public class UserSignInDto : FixDto {
    public string? Username { get; set; }
    public string Password { get; set; } = "";
    public bool Remember { get; set; }
}
