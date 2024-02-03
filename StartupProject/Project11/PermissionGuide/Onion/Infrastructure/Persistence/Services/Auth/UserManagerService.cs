using Application.Consts;
using Application.Consts.Auth;
using Application.Dtos.Auth;
using Application.Exceptions;
using Application.Interfaces.Repository.User;
using Application.Interfaces.Repository.UserClaim;
using Application.Interfaces.Service.Auth;
using AutoMapper;
using Common.ResponseObjects;
using Domain.Entities.Auth;
using Microsoft.Extensions.Logging;

namespace Persistence.Services.Auth;


public class UserManagerService : IUserManagerService {
    private readonly IUserQueryRepository _userQueryRepository;
    private readonly IUserCommandRepository _userCommandRepository;
    private readonly IApplicationUserClaimQueryRepository _applicationUserClaimQueryRepository;
    private readonly IApplicationUserClaimCommandRepository _applicationUserClaimCommandRepository;
    private readonly IRoleManagerService _roleManagerService;
    private readonly IMapper _mapper;
    private readonly ILogger<UserManagerService> _logger;


    public UserManagerService(IUserQueryRepository userQueryRepository, IUserCommandRepository userCommandRepository, IApplicationUserClaimQueryRepository applicationUserClaimQueryRepository, IApplicationUserClaimCommandRepository applicationUserClaimCommandRepository, IRoleManagerService roleManagerService, IMapper mapper, ILogger<UserManagerService> logger) {
        _userQueryRepository = userQueryRepository;
        _userCommandRepository = userCommandRepository;
        _applicationUserClaimQueryRepository = applicationUserClaimQueryRepository;
        _applicationUserClaimCommandRepository = applicationUserClaimCommandRepository;
        _roleManagerService = roleManagerService;
        _mapper = mapper;
        _logger = logger;
    }


    #region Query
    public async Task<ApplicationUser> FindByIdAsync(Guid id, bool asNoTracking = true) {
        var user = await _userQueryRepository.GetByFilterAsync(x => x.Id == id, asNoTracking);
        return user;
    }


    public async Task<ApplicationUser> FindByUserNameAsync(string username, bool asNoTracking = true) {
        var user = await _userQueryRepository.GetByFilterAsync(x => x.Username == username, asNoTracking);
        return user;
    }


    public async Task<ApplicationUser> FindByEmailAsync(string email, bool asNoTracking = true) {
        var user = await _userQueryRepository.GetByFilterAsync(x => x.Email == email, asNoTracking);
        return user;
    }


    public async Task<ApplicationUser> FindByPhoneAsync(string phone, bool asNoTracking = true) {
        var user = await _userQueryRepository.GetByFilterAsync(x => x.PhoneNumber == phone, asNoTracking);
        return user;
    }

    public async Task<ApplicationUserClaim> GetClaimAsync(Guid id, string claimType, bool asNoTracking = true) {
        var claim = await _applicationUserClaimQueryRepository.GetByFilterAsync(x => x.UserId == id && x.ClaimType == claimType, asNoTracking);
        return claim;
    }
    #endregion


    #region Command

    //TODO Username içerisinde çeşitli karakterler olmayacak kontrolü sağlanacak ve normalleştirilecek.
    public async Task<Response<UserSignUpDto>> CreateUserAsync(UserSignUpDto userSignUpDto) {
        var result = await _userQueryRepository.GetByFilterAsync(x => x.Username == userSignUpDto.Username);
        result ??= await _userQueryRepository.GetByFilterAsync(x => x.Email == userSignUpDto.Email);

        if (result != null) {
            return new(ResponseType.ValidationError, userSignUpDto, "Bu bilgiler zaten kullanılıyor.");
        }

        var newUser = _mapper.Map<ApplicationUser>(userSignUpDto);
        await _userCommandRepository.BeginTransactionAsync();

        /*BeginTransaction*/
        await _userCommandRepository.CreateAsync(newUser);
        await _roleManagerService.AssignRoleByUserAsync(newUser.Id, RoleDefaults.Member.Id);

        await SetClaim(newUser.Id, UserDefaults.ClaimsTypes.ProfilePhoto, ImageDefaults.UserProfilePhoto);
        /*EndTransaction*/

        await _userCommandRepository.CommitAsync();

        return new(ResponseType.Success, userSignUpDto, "Kullanıcı Başarıyla Oluşturuldu.");
    }


    public async Task UpdateRefreshTokenAsync(ApplicationUser entity, string refreshToken, DateTime refreshTokenExtendTime) {
        if (entity != null) {
            entity.RefreshToken = refreshToken;
            entity.RefreshTokenEndDate = refreshTokenExtendTime;
            await _userCommandRepository.UpdateAsync(entity);
            await _userCommandRepository.SaveAsync();
        } else {
            // _logger.LogError("Refresh Token Kısmında Bir Hata Oluştu");
            throw new NotFoundUserException("Refresh Token Kısmında Bir Hata Oluştu.");
        }
    }


    public async Task UpdatePasswordByIdAsync(ApplicationUser entity, string password) {
        // var user = await this.FindByIdAsync(entity.Id, asNoTracking: true);
        entity.Password = password;
        entity.SecurityStampDate = DateTime.UtcNow;
        await _userCommandRepository.UpdateAsync(entity);
        await _userCommandRepository.SaveAsync();
    }


    public async Task RemoveUserByIdAsync(Guid id) {
        var user = await _userQueryRepository.GetByIdAsync(id, asNoTracking: false);
        if (user != null && user.IsPersistent == false) {
            user.Active = false;
            // await _userCommandRepository.UpdateAsync(user);
            await _userCommandRepository.SaveAsync();
        }

    }


    public async Task RemovePermanentlyUserByIdAsync(Guid id) {
        var user = await _userQueryRepository.GetByIdAsync(id);
        if (user != null && user.IsPersistent == false) {
            _userCommandRepository.Remove(user);
            await _userCommandRepository.SaveAsync();
        }
    }


    public async Task SetClaim(Guid id, string claimType, string claimValue) {
        var claim = await GetClaimAsync(id, claimType, false);
        if (claim != null) {
            claim.ClaimValue = claimValue;
            _applicationUserClaimCommandRepository.UpdateOverwrite(claim);
            await _applicationUserClaimCommandRepository.SaveAsync();
            return;
        }
        var newClaim = new ApplicationUserClaim() {
            Id = Guid.NewGuid(),
            UserId = id,
            Active = true,
            ClaimType = claimType,
            ClaimValue = claimValue,
            IsPersistent = false
        };

        await _applicationUserClaimCommandRepository.CreateAsync(newClaim);
        await _applicationUserClaimCommandRepository.SaveAsync();
    }
    #endregion


    #region Validation
    public async Task<ApplicationUser?> CheckUserCredentialAsync(UserSignInDto model) {
        var user = await this.FindByUserNameAsync(model.Username, asNoTracking: false);

        if (user == null) {
            return default;
        }

        return user.Password == model.Password ? user : null;
    }


    public async Task<ApplicationUser> CheckRefreshTokenAsync(string refreshToken) {
        var user = await _userQueryRepository.GetByFilterAsync(x => x.RefreshToken == refreshToken, asNoTracking: false);
        if (user != null && user.RefreshTokenEndDate?.ToUniversalTime() > DateTime.UtcNow) {
            return user;
        }
        throw new NotFoundUserException();
    }
    #endregion


}
