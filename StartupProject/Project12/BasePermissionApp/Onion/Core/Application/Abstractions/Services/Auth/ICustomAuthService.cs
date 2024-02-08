using Application.Dtos.Auth;
using Application.Dtos.Token;
using Common.ResponseObjects;

namespace Application.Interfaces.Service.Auth;


public interface ICustomAuthService {
    
    Task<Response<TokenDto>> SignInAsync(UserSignInDto model);

}
