using Application.Interfaces.Repository.Endpoint;
using Application.Interfaces.Repository.Menu;
using Application.Interfaces.Repository.Role;
using Application.Interfaces.Service.Auth;
using Application.Interfaces.Service.Configurations;
using Domain.Entities.Auth;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Services.Auth;


public class EndpointManagerService : IEndpointManagerService {
    private readonly IApplicationService _applicationService;
    private readonly IEndpointQueryRepository _endpointQueryRepository;
    private readonly IEndpointCommandRepository _endpointCommandRepository;
    private readonly IMenuQueryRepository _menuQueryRepository;
    private readonly IMenuCommandRepository _menuCommandRepository;
    private readonly IRoleQueryRepository _roleQueryRepository;
    private readonly IRoleCommandRepository _roleCommandRepository;

    public EndpointManagerService(IApplicationService applicationService, IEndpointQueryRepository endpointQueryRepository, IEndpointCommandRepository endpointCommandRepository, IMenuQueryRepository menuQueryRepository, IMenuCommandRepository menuCommandRepository, IRoleQueryRepository roleQueryRepository, IRoleCommandRepository roleCommandRepository) {
        _applicationService = applicationService;
        _endpointQueryRepository = endpointQueryRepository;
        _endpointCommandRepository = endpointCommandRepository;
        _menuQueryRepository = menuQueryRepository;
        _menuCommandRepository = menuCommandRepository;
        _roleQueryRepository = roleQueryRepository;
        _roleCommandRepository = roleCommandRepository;
    }


    public async Task AssignRoleEndpointAsync(Guid roleId, string[] codes, Type type) {
        var endpoints = _applicationService.GetAuthorizedEndpoints(type);
        var appRole = await _roleQueryRepository.Table
        .Include(x => x.Endpoints)
        .Where(x => x.Id == roleId)
        .SingleOrDefaultAsync();

        if (endpoints is null || appRole is null || codes is null) {
            return;
        }

        // Rolün tüm endpoint ilişkilerini kaldır, yetkinin var olup olmadığı ile uğraşma
        _endpointCommandRepository.RemoveRange(appRole.Endpoints.ToList());
        await _endpointCommandRepository.SaveAsync();

        // Kullanılacak menüleri(controllers) bul
        var menus = endpoints.Where(x => x.Actions.Any(a => codes.Contains(a.Code)));
        foreach (var menu in menus) {
            // Menü yoksa ekle
            ApplicationMenu applicationMenu = await _menuQueryRepository.GetByFilterAsync(m => m.Name == menu.Name, false);
            if (applicationMenu == null) {
                applicationMenu = new() {
                    Id = Guid.NewGuid(),
                    Name = menu.Name
                };
                await _menuCommandRepository.CreateAsync(applicationMenu);
                await _menuCommandRepository.SaveAsync();
            }

            // Yetki verilmesi beklenen menü içerisindeki actionları(endpoints) al (tüm actionlar unique code'a sahip)
            var actions = menu.Actions.Where(x => codes.Contains(x.Code));
            foreach (var action in actions) {
                var _endpoint = new ApplicationEndpoint() {
                    Code = action.Code,
                    ActionType = action.ActionType,
                    HttpType = action.HttpType,
                    Definition = action.Definition,
                    Id = Guid.NewGuid(),
                    Menu = applicationMenu
                };
                await _endpointCommandRepository.CreateAsync(_endpoint);

                appRole.Endpoints.Add(_endpoint);
            }

            await _endpointCommandRepository.SaveAsync();
            await _roleCommandRepository.SaveAsync();
        }

    }


    public async Task<List<ApplicationEndpoint>> GetEndpointsByRoleAsync(Guid id) {
        /*
            Id si verilen rolün, eşleştirildiği endpointlerin listesini döndürür.
        */
        var results = await _endpointQueryRepository.Table
        .Include(x => x.Roles)
        .Where(x => x.Roles.Any(x => x.Id == id))
        .ToListAsync();
        return results;
    }


    public async Task<List<string>> GetUserEndpointIdentifiersByUserAsync(Guid id, Type type) {
        /*
            Kullanıcının yetkiye sahip olduğu endpointlerin Identifier'larını döndürür.
        */
        var endpoints = await _endpointQueryRepository.Table
        .Include(x => x.Roles)
        .ThenInclude(x => x.ApplicationUserRoles)
        .Where(x => x.Roles.Any(x => x.ApplicationUserRoles.Any(x => x.UserId == id))).ToListAsync();

        var allEndpoints = _applicationService.GetAuthorizedEndpoints(type);

        var userAuthorizedEndpointIdentifiers = allEndpoints.SelectMany(menu =>
            menu.Actions.Where(x => endpoints.Any(e => e.Code == x.Code)).Select(x => x.Identifier)
        ).ToList();

        return userAuthorizedEndpointIdentifiers;
    }


    // public async Task<List<string>> GetUserEndpointIdentifiersByUserAsync(string username, Type type) {
    //     /*
    //         Kullanıcının yetkiye sahip olduğu endpointlerin Identifier'larını döndürür.
    //     */
    //     var endpoints = await _endpointQueryRepository.Table
    //     .Include(x => x.Roles)
    //     .ThenInclude(x => x.ApplicationUserRoles)
    //     .ThenInclude(x => x.User)
    //     .Where(x => x.Roles.Any(x => x.ApplicationUserRoles.Any(x => x.User.Username == username))).ToListAsync();

    //     var allEndpoints = _applicationService.GetAuthorizedEndpoints(type);

    //     var userAuthorizedEndpointIdentifiers = allEndpoints.SelectMany(menu =>
    //         menu.Actions.Where(x => endpoints.Any(e => e.Code == x.Code)).Select(x => x.Identifier)
    //     ).ToList();

    //     return userAuthorizedEndpointIdentifiers;
    // }


}
