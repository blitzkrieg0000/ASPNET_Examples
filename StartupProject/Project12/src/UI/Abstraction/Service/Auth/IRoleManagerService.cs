using UI.Dto.UserRole;

namespace UI.Abstraction.Service.Auth;


public interface IRoleManagerService {

    Task<List<UserRoleAuthDto>> GetRolesByUserAsync(Guid userGuid);

    Task AddRoleAsync(string roleName);

    Task RemoveRoleAsync(Guid roleGuid);

    Task AssignRoleByUserAsync(Guid userGuid, Guid roleGuid);

    Task AssignRoleRangeByUserAsync(Guid userGuid, List<Guid> roles);

    Task UnAssignRoleByUserAsync(Guid userGuid, Guid roleGuid);
}
