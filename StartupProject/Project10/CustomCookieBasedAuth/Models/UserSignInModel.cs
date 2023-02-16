namespace CustomCookieBasedAuth.Models;
public class UserSignInModel {

    public string? Username { get; set; }
    public string? Password { get; set; }
    public bool Remember { get; set; }
}