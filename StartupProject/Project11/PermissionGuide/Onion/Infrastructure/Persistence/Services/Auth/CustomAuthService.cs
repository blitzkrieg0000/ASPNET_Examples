using System.Security.Claims;
using Application.Consts;
using Application.Consts.Auth;
using Application.Dtos.Auth;
using Application.Dtos.Token;
using Application.Exceptions;
using Application.Extensions;
using Application.Interfaces.Service.Auth;
using Application.Interfaces.Service.Hash;
using Application.Interfaces.Service.Mail;
using Application.Interfaces.Service.Token;
using Application.Models.Auth;
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
    private readonly IMailService _mailService;
    private readonly IJwtTokenGeneratorService _jwtTokenGeneratorService;
    private readonly IHashService _hashService;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ILogger<CustomAuthService> _logger;
    private readonly IConfiguration _configuration;

    public CustomAuthService(IUserManagerService userManagerService, IRoleManagerService roleManagerService, IMailService mailService, IJwtTokenGeneratorService jwtTokenGeneratorService, IHashService hashService, IHttpContextAccessor httpContextAccessor, ILogger<CustomAuthService> logger, IConfiguration configuration) {
        _userManagerService = userManagerService;
        _roleManagerService = roleManagerService;
        _mailService = mailService;
        _jwtTokenGeneratorService = jwtTokenGeneratorService;
        _hashService = hashService;
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
            new Claim(ClaimTypes.Name, entity.Username),
            new Claim(UserDefaults.ClaimsTypes.UserId, entity.Id.ToString())
        };

        // Add ProfilePhoto 
        var profilePhoto = await _userManagerService.GetClaimAsync(entity.Id, UserDefaults.ClaimsTypes.ProfilePhoto);
        if (profilePhoto != null && profilePhoto.ClaimValue != null) {
            claims.Add(new Claim(UserDefaults.ClaimsTypes.ProfilePhoto, profilePhoto.ClaimValue));
        } else {
            claims.Add(new Claim(UserDefaults.ClaimsTypes.ProfilePhoto, ImageDefaults.UserProfilePhoto));
        }

        // Add Absolute Identifier Role
        var roles = await _roleManagerService.GetRolesByUserAsync(entity.Id);
        if (roles.Any(x => x.RoleName == RoleDefaults.SuperUser.Name)) {
            claims.Add(new Claim(ClaimTypes.Role, RoleDefaults.SuperUser.Name));
        } else if (roles.Any(x => x.RoleName == RoleDefaults.Admin.Name)) {
            claims.Add(new Claim(ClaimTypes.Role, RoleDefaults.Admin.Name));
        } else {
            claims.Add(new Claim(ClaimTypes.Role, RoleDefaults.Member.Name));
        }

        return claims;
    }


    private async Task<T> InternalSignInDefaultsAsync<T>(ApplicationUser entity, bool remember, Func<TokenDto, List<Claim>, bool, Task<T>> signInCallback) {
        //! Tüm giriş türleri için fix işlemler------------------------------------------
        // Claims oluştur.
        var claims = await this.CreateClaimsViaUserAsync(entity);

        // Claimler ile JWT oluştur.
        var tokens = _jwtTokenGeneratorService.CreateJWT(claims);

        // Kullanıcının Refresh Token'ini database'de güncelle.
        await _userManagerService.UpdateRefreshTokenAsync(entity, tokens.RefreshToken, tokens.RefreshTokenExpireTime);

        return await signInCallback(tokens, claims, remember);
    }
    #endregion


    #region SignInCallbacks
    private async Task<Response<TokenDto>> CallbackCookieAuthenticationAsync(TokenDto token, List<Claim> claims, bool isPersistent) {
        // JWT Token'i Cookielere ekle
        claims.Add(new Claim("jwtToken", token.AccessToken));

        // Kullanıcı Kimliği
        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        // Kullanıcı Oturum Ayarı
        var authProperties = new AuthenticationProperties {
            // AllowRefresh = true,
            ExpiresUtc = token.AuthCookieExpireTime,
            IsPersistent = isPersistent,
        };

        // Try SignIn: Bu işlem gerekli cookieleri oluşturur.
        try {
            // CookieBasedAuthentication şeması için ilgili bilgileri cookie'ye kaydeder.
            await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
            return new(ResponseType.Success, token, "Giriş işlemi başarılı.");
        } catch (System.Exception) {
            _logger.LogError("Giriş işleminde bir hata oluştu.");
            throw new NotFoundUserException();
        }
    }


    private async Task<Response<TokenDto>> CallbackJWTAuthenticationAsync(TokenDto token, List<Claim> claims, bool isPersistent) {
        return new Response<TokenDto>(ResponseType.Success, token, "Başarılı.");
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


    public async Task<Response<TokenDto>> ApiSignInAsync(UserSignInDto model) {
        var user = await _userManagerService.CheckUserCredentialAsync(model);

        return user switch {
            null => new(ResponseType.ValidationError, "Kullanıcı adı veya parola yanlış"),
            _ when user.Active == false => new(ResponseType.ValidationError, "Kullanıcı Erişime Kapalı"),
            _ => await InternalSignInDefaultsAsync(user, model.Remember, CallbackJWTAuthenticationAsync)
        };
    }
    #endregion

    #region Token
    #region RefreshToken
    public async Task<Response<TokenDto>> RefreshTokenSignInAsync(string refreshToken) {
        var user = await _userManagerService.CheckRefreshTokenAsync(refreshToken);

        var response = await this.SignInAsync(new UserSignInDto() {
            Username = user.Username,
            Password = user.Password
        });

        response.Message = "Sayfa Güncellendi.";
        return response;
    }


    public async Task<Response<TokenDto>> ApiRefreshTokenSignInAsync(string refreshToken) {
        try {
            var user = await _userManagerService.CheckRefreshTokenAsync(refreshToken);
            var response = await this.ApiSignInAsync(new UserSignInDto() {
                Username = user.Username,
                Password = user.Password
            });

            response.Message = "Token Güncellendi.";
            return response;
        } catch (NotFoundUserException) {
            return new(ResponseType.NotFound, "Geçersiz RefreshToken");
        }
    }
    #endregion


    #region ResetToken
    public async Task<Response> ResetPasswordAsync(ResetPasswordModel dto) {
        var user = await _userManagerService.FindByUserNameAsync(dto.UserIdentifier, asNoTracking: true);
        user ??= await _userManagerService.FindByEmailAsync(dto.UserIdentifier, asNoTracking: true);
        user ??= await _userManagerService.FindByPhoneAsync(dto.UserIdentifier, asNoTracking: true);

        if (user == null) {
            return new(ResponseType.ValidationError, "Parolanızı yenilemek için email adresinize gönderdiğimiz linke tıklayınız.");
        }

        var secretKey = _hashService.GetHashSha3_512(user.Password + _configuration["ResetPassword:Secret"]);

        var claims = new List<Claim>{
            new Claim("Id", user.Id.ToString())
        };

        var resetPasswordJWT = _jwtTokenGeneratorService.CreateJWT(claims, secretKey, double.Parse(_configuration["ResetPassword:ExpireTimeSeconds"]));

        await _mailService.SendResetPasswordMailAsync(user.Email, resetPasswordJWT.AccessToken.UrlEncode());

        return new Response(ResponseType.Success, "Parolanızı yenilemek için email adresinize gönderdiğimiz linke tıklayınız.");
    }


    public async Task<Response<ApplicationUser>> VerifyResetTokenAsync(string token) {
        token = token.UrlDecode();
        var tokenData = _jwtTokenGeneratorService.ReadTokenData(token);

        if (tokenData == null) {
            return new(ResponseType.ValidationError);
        }

        var claims = tokenData.Claims.ToList();
        var claimId = claims.Where(x => x.Type.Equals("Id")).FirstOrDefault();

        if (claimId != null && claimId.Value != null) {
            var user = await _userManagerService.FindByIdAsync(Guid.Parse(claimId.Value), false);

            if (user.SecurityStampDate.ToUniversalTime() > tokenData.ValidFrom) {
                return new(ResponseType.ValidationError);
            }

            var secretKey = _hashService.GetHashSha3_512(user.Password + _configuration["ResetPassword:Secret"]);
            var result = await _jwtTokenGeneratorService.VerifyResetPasswordTokenAsync(token, secretKey);
            return result.IsValid ? new Response<ApplicationUser>(ResponseType.Success, user) : new(ResponseType.ValidationError);
        }

        return new(ResponseType.ValidationError);
    }


    public async Task<Response> UpdatePasswordAsync(UpdatePasswordModel model) {

        var result = await VerifyResetTokenAsync(model.ResetPasswordToken);

        if (result.ResponseType == ResponseType.Success) {
            model.NewPassword = _hashService.GetHashSha3_512(model.NewPassword);
            await _userManagerService.UpdatePasswordByIdAsync(result.Data, model.NewPassword);
            return new Response(ResponseType.Success, "Parolanız Başarıyla Yenilendi.");
        }

        return new Response(ResponseType.ValidationError, "Parola yenileme süreniz dolmuştur. 'Parolamı Unuttum' bölümünden tekrar parola yenileme talebinde bulunabilirsiniz.");
    }
    #endregion
    #endregion

}
