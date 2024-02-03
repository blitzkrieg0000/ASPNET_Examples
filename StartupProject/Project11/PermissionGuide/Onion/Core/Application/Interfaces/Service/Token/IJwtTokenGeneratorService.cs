using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Application.Dtos.Token;
using Microsoft.IdentityModel.Tokens;

namespace Application.Interfaces.Service.Token;


public interface IJwtTokenGeneratorService {

    TokenDto CreateJWT(List<Claim>? claims);

    TokenDto CreateJWT(List<Claim>? claims, string secretKey, double expireTimeSeconds);

    string CreateRefreshToken();

    Task<TokenValidationResult> VerifyResetPasswordTokenAsync(string token, string secretKey);

    JwtSecurityToken? ReadTokenData(string token);

}
