using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Application.Dtos.Token;
using Application.Extensions;
using Application.Interfaces.Service.Token;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Services.Token.JWT;


public class JwtTokenGeneratorService : IJwtTokenGeneratorService {

    readonly IConfiguration _configuration;

    public JwtTokenGeneratorService(IConfiguration configuration) {
        _configuration = configuration;
    }


    public TokenDto CreateJWT(List<Claim>? claims) {
        return CreateJWT(claims, _configuration["Bearer:Key"], double.Parse(_configuration["Bearer:ExpireTimeSeconds"]));
    }


    public TokenDto CreateJWT(List<Claim>? claims, string secretKey, double expireTimeSeconds) {
        TokenDto token = new();

        // Credentials
        SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(secretKey));
        SigningCredentials credentials = new(key, SecurityAlgorithms.HmacSha512);

        // Token
        token.ExpireTime = DateTime.UtcNow.AddSeconds(expireTimeSeconds).ToUniversalTime();

        JwtSecurityToken accessToken = new(
            issuer: _configuration["Bearer:Issuer"],
            audience: _configuration["Bearer:Audience"],
            claims: claims,
            notBefore: DateTime.UtcNow,
            expires: token.ExpireTime,
            signingCredentials: credentials
        );

        // Handler
        JwtSecurityTokenHandler handler = new();

        token.AccessToken = handler.WriteToken(accessToken);
        token.RefreshToken = CreateRefreshToken();
        token.AuthCookieExpireTime = DateTime.UtcNow.AddSeconds(double.Parse(_configuration["AuthCookie:ExpireTimeSeconds"]));
        token.RefreshTokenExpireTime = token.AuthCookieExpireTime.AddSeconds(double.Parse(_configuration["Bearer:ExpireRefreshTokenExtendTimeSeconds"]));

        return token;
    }


    public string CreateRefreshToken() {
        byte[] number = new byte[32];
        using RandomNumberGenerator random = RandomNumberGenerator.Create();
        random.GetBytes(number);
        return Convert.ToBase64String(number).UrlEncode();
    }


    public async Task<TokenValidationResult> VerifyResetPasswordTokenAsync(string token, string secretKey) {
        JwtSecurityTokenHandler handler = new();
        var validationToken = new TokenValidationParameters() {
            ValidateLifetime = true,
            ValidateAudience = false,
            ValidateIssuer = false,
            ValidIssuer = _configuration["Host:Domain"],
            ValidAudience = _configuration["Host:Domain"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)) // The same key as the one that generate the token
        };

        return await handler.ValidateTokenAsync(token, validationToken);

    }


    public JwtSecurityToken? ReadTokenData(string token) {
        JwtSecurityTokenHandler handler = new();
        return handler.ReadJwtToken(token);
    }

}
