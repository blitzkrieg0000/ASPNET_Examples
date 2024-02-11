using AutoMapper;
using UI.Abstraction.Repository.User;
using UI.Abstraction.Service.Auth;
using UI.Common.ResponseObject;
using UI.Const.Auth;
using UI.Dto.Auth;
using UI.Entities.Auth;

namespace Persistence.Services.Auth;


public class UserManagerService : IUserManagerService {
    private readonly IUserQueryRepository _userQueryRepository;
    private readonly IUserCommandRepository _userCommandRepository;
    private readonly IRoleManagerService _roleManagerService;
    private readonly IMapper _mapper;
    private readonly ILogger<UserManagerService> _logger;

    public UserManagerService(IUserQueryRepository userQueryRepository, IUserCommandRepository userCommandRepository, IRoleManagerService roleManagerService, IMapper mapper, ILogger<UserManagerService> logger) {
        _userQueryRepository = userQueryRepository;
        _userCommandRepository = userCommandRepository;
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
        // await _userCommandRepository.BeginTransactionAsync();

        /*BeginTransaction*/
        userSignUpDto.Id = await _userCommandRepository.CreateAsync(newUser);
        await _roleManagerService.AssignRoleByUserAsync(newUser.Id, RoleDefaults.Member.Id);
        /*EndTransaction*/

        // await _userCommandRepository.CommitAsync();
        await _userCommandRepository.SaveAsync();

        return new(ResponseType.Success, userSignUpDto, "Kullanıcı Başarıyla Oluşturuldu.");
    }


    public async Task UpdatePasswordByIdAsync(ApplicationUser entity, string password) {
        // var user = await this.FindByIdAsync(entity.Id, asNoTracking: true);
        entity.Password = password;
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
    #endregion


    #region Validation
    public async Task<ApplicationUser?> CheckUserCredentialAsync(UserSignInDto model) {
        var user = await this.FindByUserNameAsync(model.Username, asNoTracking: false);

        if (user == null) {
            return default;
        }

        return user.Password == model.Password ? user : null;
    }
    #endregion
}
