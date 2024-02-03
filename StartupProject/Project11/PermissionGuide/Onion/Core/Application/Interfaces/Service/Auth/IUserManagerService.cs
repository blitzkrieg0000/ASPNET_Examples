using Application.Dtos.Auth;
using Common.ResponseObjects;
using Domain.Entities.Auth;

namespace Application.Interfaces.Service.Auth;


public interface IUserManagerService {

    Task<ApplicationUser> FindByIdAsync(Guid id, bool asNoTracking = true);

    Task<ApplicationUser> FindByUserNameAsync(string username, bool asNoTracking = true);

    Task<ApplicationUser> FindByEmailAsync(string email, bool asNoTracking = true);

    Task<ApplicationUser> FindByPhoneAsync(string phone, bool asNoTracking = true);

    Task<ApplicationUserClaim> GetClaimAsync(Guid id, string claimType, bool asNoTracking = true);

    Task SetClaim(Guid id, string claimType, string claimValue);

    Task<ApplicationUser?> CheckUserCredentialAsync(UserSignInDto model);

    Task<Response<UserSignUpDto>> CreateUserAsync(UserSignUpDto userSignUpDto);

    Task UpdateRefreshTokenAsync(ApplicationUser entity, string refreshToken, DateTime refreshTokenExtendTime);

    Task<ApplicationUser> CheckRefreshTokenAsync(string refreshToken);

    Task UpdatePasswordByIdAsync(ApplicationUser entity, string password);

    Task RemoveUserByIdAsync(Guid id);

    Task RemovePermanentlyUserByIdAsync(Guid id);

}