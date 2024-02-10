using UI.Common.ResponseObject;
using UI.Const.Auth;
using UI.Dto.Auth;

namespace UI.Abstraction.Service.Auth;


public interface ICustomAuthService {
    
    Task<Response> SignInAsync(UserSignInDto model);
    
    Task<Response<Page>> SignInRedirectionManagementAsync(string user_id);
    
}
