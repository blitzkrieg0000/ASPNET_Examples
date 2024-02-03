using Application.Dtos.Auth;
using Application.Dtos.Token;
using Application.Models.Auth;
using Common.ResponseObjects;

namespace Application.Interfaces.Service.Auth;


public interface ICustomAuthService {
    
    Task<Response<TokenDto>> SignInAsync(UserSignInDto model);

    Task<Response<TokenDto>> ApiSignInAsync(UserSignInDto model);

    Task<Response<TokenDto>> RefreshTokenSignInAsync(string refreshToken);

    Task<Response<TokenDto>> ApiRefreshTokenSignInAsync(string refreshToken);

    Task<Response> ResetPasswordAsync(ResetPasswordModel dto);

    Task<Response> UpdatePasswordAsync(UpdatePasswordModel token);

}
