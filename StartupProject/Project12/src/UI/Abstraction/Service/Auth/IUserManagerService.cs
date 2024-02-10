using UI.Common.ResponseObject;
using UI.Dto.Auth;
using UI.Entities.Auth;

namespace UI.Abstraction.Service.Auth;


public interface IUserManagerService {

    Task<ApplicationUser> FindByIdAsync(Guid id, bool asNoTracking = true);

    Task<ApplicationUser> FindByUserNameAsync(string username, bool asNoTracking = true);

    Task<ApplicationUser> FindByEmailAsync(string email, bool asNoTracking = true);

    Task<ApplicationUser> FindByPhoneAsync(string phone, bool asNoTracking = true);

    Task<ApplicationUser?> CheckUserCredentialAsync(UserSignInDto model);

    Task<Response<UserSignUpDto>> CreateUserAsync(UserSignUpDto userSignUpDto);

    Task UpdatePasswordByIdAsync(ApplicationUser entity, string password);

    Task RemoveUserByIdAsync(Guid id);

    Task RemovePermanentlyUserByIdAsync(Guid id);

}