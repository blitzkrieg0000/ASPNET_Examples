using Domain.Entities.Auth;

namespace Application.Interfaces.Service.Auth;


public interface IEndpointManagerService {

    Task AssignRoleEndpointAsync(Guid roleId, string[] codes, Type type);

    Task<List<ApplicationEndpoint>> GetEndpointsByRoleAsync(Guid id);

    Task<List<string>> GetUserEndpointIdentifiersByUserAsync(Guid id, Type type);

    // Task<List<string>> GetUserEndpointIdentifiersByUserAsync(string name, Type type);
}
