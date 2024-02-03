namespace Application.Dtos.Token;


public class TokenDto : FixDto {
    public string? AccessToken { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime ExpireTime { get; set; }
    public DateTime RefreshTokenExpireTime { get; set; }
    public DateTime AuthCookieExpireTime { get; set; }
    
}
