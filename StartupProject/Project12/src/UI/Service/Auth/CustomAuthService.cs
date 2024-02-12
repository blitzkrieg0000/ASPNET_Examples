using System.Security.Claims;
using Application.Consts;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using UI.Abstraction.Service.Auth;
using UI.Common.ResponseObject;
using UI.Const.Auth;
using UI.Dto.Auth;
using UI.Entities.Auth;
using UI.Exceptions;

namespace Persistence.Services.Auth;


public class CustomAuthService : ICustomAuthService {
    private readonly IUserManagerService _userManagerService;
    private readonly IRoleManagerService _roleManagerService;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ILogger<CustomAuthService> _logger;
    private readonly IConfiguration _configuration;

    public CustomAuthService(IUserManagerService userManagerService, IRoleManagerService roleManagerService, IHttpContextAccessor httpContextAccessor, ILogger<CustomAuthService> logger, IConfiguration configuration) {
        _userManagerService = userManagerService;
        _roleManagerService = roleManagerService;
        _httpContextAccessor = httpContextAccessor;
        _logger = logger;
        _configuration = configuration;
    }


    #region SignInOperations
    private async Task<List<Claim>> CreateClaimsViaUserAsync(ApplicationUser entity) {
        //? Claim : Kullanıcının hassas olmayan verilerini key-value şeklinde tutan yapıdır. 
        //? Claim'ler, Identity'leri oluşturmak için kullanılırlar. Identity'ler birden fazla claim tutabilir.
        //? Identity kütüphanelerinin gerekli "SignIn" işlemleri ile bu identityler(giriş kartları) aktifleştirilir.
        //? Custom Cookie Based Auth' da ClaimsPrincipal nesnesi bu işleri yönetir. "HttpContext" nesnesi ile gerekli işler yapılır.
        //! Claimler cookielere yazıldığından, cookieler her http-requestte http header'a eklenerek server tarafına gelecektir. Bu göz önünde bulundurulmalı ve cookie'ler şişirilmemelidir.

        // Create Claim List
        var claims = new List<Claim>{
            new(ClaimTypes.Name, entity.Username),
            new(UserDefaults.ClaimsTypes.UserId, entity.Id.ToString())
        };

        // Add Absolute Identifier Role
        var roles = await _roleManagerService.GetRolesByUserAsync(entity.Id);
        if (roles.Any(x => x.RoleName == RoleDefaults.SuperUser.Name)) {
            claims.Add(new Claim(ClaimTypes.Role, RoleDefaults.SuperUser.Name));
        }
        else if (roles.Any(x => x.RoleName == RoleDefaults.Admin.Name)) {
            claims.Add(new Claim(ClaimTypes.Role, RoleDefaults.Admin.Name));
        }
        else {
            claims.Add(new Claim(ClaimTypes.Role, RoleDefaults.Member.Name));
            foreach (var role in roles) {       // roles.Take(3)
                if (role.RoleName != null) {
                    claims.Add(new Claim(ClaimTypes.Role, role.RoleName));
                }
            }
        }

        return claims;
    }


    private async Task<T> InternalSignInDefaultsAsync<T>(ApplicationUser entity, bool remember, Func<List<Claim>, bool, Task<T>> signInCallback) {
        //! Tüm giriş türleri için fix işlemler
        // Claims oluştur.
        var claims = await this.CreateClaimsViaUserAsync(entity);
        return await signInCallback(claims, remember);
    }
    #endregion


    #region SignInCallbacks
    private async Task<Response> CallbackCookieAuthenticationAsync(List<Claim> claims, bool isPersistent) {

        // Kullanıcı Kimliği
        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        // Kullanıcı Oturum Ayarı
        var authProperties = new AuthenticationProperties {
            // AllowRefresh = true,
            ExpiresUtc = DateTime.UtcNow.AddSeconds(double.Parse(_configuration["AuthCookie:ExpireTimeSeconds"])),
            IsPersistent = isPersistent,
        };

        // Try SignIn: Bu işlem gerekli cookieleri oluşturur.
        try {
            // CookieBasedAuthentication şeması için ilgili bilgileri cookie'ye kaydeder.
            await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
            return new(ResponseType.Success, "Giriş işlemi başarılı.");
        }
        catch (System.Exception) {
            _logger.LogError("Giriş işleminde bir hata oluştu.");
            throw new NotFoundUserException();
        }
    }
    #endregion


    #region SignIn
    public async Task<Response> SignInAsync(UserSignInDto model) {
        var user = await _userManagerService.CheckUserCredentialAsync(model);

        return user switch {
            null => new(ResponseType.ValidationError, "Kullanıcı adı veya parola yanlış"),
            _ when user.Active == false => new(ResponseType.ValidationError, "Kullanıcı Erişime Kapalı"),
            _ => await InternalSignInDefaultsAsync(user, model.Remember, CallbackCookieAuthenticationAsync),
        };
    }
    #endregion


    public async Task<Response<Page>> SignInRedirectionManagementAsync(string user_id) {

        if (!string.IsNullOrEmpty(user_id)) {
            var roles = await _roleManagerService.GetRolesByUserAsync(Guid.Parse(user_id));

            //! SUPERUSER || ADMIN
            // if (roles.Any(x => x.RoleName == RoleDefaults.SuperUser.Name || x.RoleName == RoleDefaults.Admin.Name)) {
            //     return new(ResponseType.Success, SignInDefaults.RedirectionPages.AdminPage);
            // }

            //! MEMBER
            // if (roles.Any(x => x.RoleName == RoleDefaults.Member.Name)) {
            //     return new(ResponseType.Success, SignInDefaults.RedirectionPages.MemberPage);
            // }

            return new(ResponseType.Success, SignInDefaults.RedirectionPages.AdminPage);

        }
        return new(ResponseType.NotAllowed, "Giriş Yapınız.");
    }

}
