using Application.Consts;
using Application.Interfaces.Service.Auth;
using Application.Interfaces.Service.Redis;
using Microsoft.AspNetCore.Razor.TagHelpers;
using UI.Extensions;

namespace UI.TagHelpers.HasPermission;

[HtmlTargetElement("permission")]
[HtmlTargetElement(Attributes = nameof(Permission))]
public class EndpointPermissionTagHelper : TagHelper {
    private string permission;
    public object Permission {
        get { return permission; }
        set { permission = $"{value.GetType().FullName}+{value.GetType().GetEnumName(value)}"; } //TODO Metotlaştırılsa güzel bir görüntü olurdu. :D
    }
    private const double CacheExpireSeconds = 1800.0;
    private const string UserNamePrefix = "__endpointPermissionCache_";
    private readonly IRedisCacheService _redisCacheService;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IEndpointManagerService _endpointManagerService;

    public EndpointPermissionTagHelper(IRedisCacheService redisCacheService, IHttpContextAccessor httpContextAccessor, IEndpointManagerService endpointManagerService) {
        _redisCacheService = redisCacheService;
        _httpContextAccessor = httpContextAccessor;
        _endpointManagerService = endpointManagerService;
    }


    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output) {
        var userClaim = _httpContextAccessor.HttpContext?.User.Claims.Where(x => x.Type == UserDefaults.ClaimsTypes.UserId).FirstOrDefault();

        if (userClaim != null) {
            // SecondLevel Cache Redis: EFCore'un first level cache'i zaten bir çok noktada aynı sorguyu defalarca kez atmıyor. Fakat her ScopedDI da context illa 1 adet sorgu atıyor.
            // Kullanıcının her isteğinde, aynı kullanıcıya ait, uzunca süre değişmeyen verileri sorgulamak yerine cacheden çekiyor.
            // Cache süresi şuanlık 3600 saniye ayarlandı. ViewEngine cache ise 60 saniye olarak ayarlı durumda. Yani iki cache var. Birisi sorgu için diğeri view için.
            // View cache in süresi biterse bu componente istek yapacak ve bilgileri tekrar alacak. Bu cache veri tabanına sorgu trafiğini "çok kritik" düzeyde çoklu kullanıcılar azaltacak.
            // Cacheler key olarak kullanıcı adı ve bir prefix'e göre tutuluyor.
            string key = $"{UserNamePrefix}{userClaim.Value}";

            var cache = await _redisCacheService.GetDataAsync<List<string?>>(key);
            if (cache == null) {
                cache = await _endpointManagerService.GetUserEndpointIdentifiersByUserAsync(Guid.Parse(userClaim.Value), typeof(Program));
                if (cache != null) {
                    await _redisCacheService.SetDataAsync(key, cache, DateTimeOffset.Now.AddSeconds(CacheExpireSeconds));
                }
            }

            //Todo SuperUser Kontrolünü değiştir. Rol sistemini de authorization kontrol sistemi ile değiştir.
            if (
                _httpContextAccessor.HttpContext?.User.GetCurrentUserName() != UserDefaults.Users.SuperUser.Username 
                && cache!=null 
                && !cache.Contains(permission)
            ) {
                output.SuppressOutput();
            };
        }
    }

}
