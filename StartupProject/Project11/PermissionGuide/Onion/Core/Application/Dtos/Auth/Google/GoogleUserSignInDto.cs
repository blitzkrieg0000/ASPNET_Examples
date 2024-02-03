namespace Application.Dtos.Auth.Google;


public class GoogleUserSignInDto : FixDto {
    public string? IdToken { get; set; }
    public string? Email { get; set; }
    public string? Name { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? PhotoUrl { get; set; }
    public string? Provider { get; set; }
}
