using System.Security.Claims;
using Application.Consts;
using Application.Consts.Auth;
using Application.Dtos.Auth;
using Application.Dtos.Token;
using Application.Exceptions;
using Application.Interfaces.Service.Auth;
using Common.ResponseObjects;
using Domain.Entities.Auth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

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

        // Add ProfilePhoto 
        var profilePhoto = await _userManagerService.GetClaimAsync(entity.Id, UserDefaults.ClaimsTypes.ProfilePhoto);
        if (profilePhoto != null && profilePhoto.ClaimValue != null) {
            claims.Add(new Claim(UserDefaults.ClaimsTypes.ProfilePhoto, profilePhoto.ClaimValue));
        }
        else {
            claims.Add(new Claim(UserDefaults.ClaimsTypes.ProfilePhoto, ImageDefaults.UserProfilePhoto));
        }

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
        }

        return claims;
    }


    private async Task<T> InternalSignInDefaultsAsync<T>(ApplicationUser entity, bool remember, Func<List<Claim>, bool, Task<T>> signInCallback) {
        //! Tüm giriş türleri için fix işlemler------------------------------------------
        // Claims oluştur.
        var claims = await this.CreateClaimsViaUserAsync(entity);


        return await signInCallback(claims, remember);
    }
    #endregion


    #region SignInCallbacks
    private async Task<Response<TokenDto>> CallbackCookieAuthenticationAsync(List<Claim> claims, bool isPersistent) {

        // Kullanıcı Kimliği
        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        // Kullanıcı Oturum Ayarı
        var authProperties = new AuthenticationProperties {
            // AllowRefresh = true,
            ExpiresUtc = DateTime.UtcNow.AddSeconds(double.Parse(_configuration["AuthCookie:ExpireTimeSeconds"]!)),
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
    public async Task<Response<TokenDto>> SignInAsync(UserSignInDto model) {
        var user = await _userManagerService.CheckUserCredentialAsync(model);

        return user switch {
            null => new(ResponseType.ValidationError, "Kullanıcı adı veya parola yanlış"),
            _ when user.Active == false => new(ResponseType.ValidationError, "Kullanıcı Erişime Kapalı"),
            _ => await InternalSignInDefaultsAsync(user, model.Remember, CallbackCookieAuthenticationAsync),
        };
    }
    #endregion
}
