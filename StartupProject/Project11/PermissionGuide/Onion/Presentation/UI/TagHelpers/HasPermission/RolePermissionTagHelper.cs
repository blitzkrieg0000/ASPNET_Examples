using Application.Consts;
using Application.Dtos.UserRole;
using Application.Interfaces.Service.Auth;
using Application.Interfaces.Service.Redis;
using Microsoft.AspNetCore.Razor.TagHelpers;
using UI.Extensions;
using C = Application.Consts.Auth;

namespace UI.TagHelpers.HasPermission;


[HtmlTargetElement("RolePermission")]
public class RolePermissionTagHelper : TagHelper {
    private const double CacheExpireSeconds = 1800.0;
    private const string UserNamePrefix = "__rolePermissionCache_";
    public C::Role Role { get; set; }
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IRedisCacheService _redisCacheService;
    private readonly IRoleManagerService _roleManagerService;

    public RolePermissionTagHelper(IHttpContextAccessor httpContextAccessor, IRedisCacheService redisCacheService, IRoleManagerService roleManagerService) {
        _httpContextAccessor = httpContextAccessor;
        _redisCacheService = redisCacheService;
        _roleManagerService = roleManagerService;
    }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output) {
        var userClaim = _httpContextAccessor.HttpContext?.User.Claims.Where(x => x.Type == UserDefaults.ClaimsTypes.UserId).FirstOrDefault();

        if (userClaim != null) {
            string key = $"{UserNamePrefix}{userClaim.Value}";

            var cache = await _redisCacheService.GetDataAsync<List<UserRoleAuthDto>>(key);
            if (cache == null) {
                cache = await _roleManagerService.GetRolesByUserAsync(Guid.Parse(userClaim.Value));
                if (cache != null) {
                    await _redisCacheService.SetDataAsync(key, cache, DateTimeOffset.Now.AddSeconds(CacheExpireSeconds));
                }
            }

            //Todo SuperUser Kontrolünü değiştir. Rol sistemini de authorization kontrol sistemi ile değiştir.
            if (
                _httpContextAccessor.HttpContext?.User.GetCurrentUserName() != UserDefaults.Users.SuperUser.Username
                && cache != null
                && !cache.Any(x => x.RoleId == Role.Id)
            ) {
                output.SuppressOutput();
            };
        }
    }

}
