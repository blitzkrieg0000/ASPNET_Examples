using Application.Abstractions.Repository.Role;
using Application.Abstractions.Repository.UserRole;
using Application.Consts.Auth;
using Application.Dtos.UserRole;
using Application.Interfaces.Service.Auth;
using Domain.Entities.Auth;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Services.Auth;


public class RoleManagerService : IRoleManagerService {
    private readonly IRoleCommandRepository _roleCommandRepository;
    private readonly IRoleQueryRepository _roleQueryRepository;
    private readonly IUserRoleCommandRepository _userRoleCommandRepository;
    private readonly IUserRoleQueryRepository _userRoleQueryRepository;

    public RoleManagerService(IRoleCommandRepository roleCommandRepository, IRoleQueryRepository roleQueryRepository, IUserRoleCommandRepository userRoleCommandRepository, IUserRoleQueryRepository userRoleQueryRepository) {
        _roleCommandRepository = roleCommandRepository;
        _roleQueryRepository = roleQueryRepository;
        _userRoleCommandRepository = userRoleCommandRepository;
        _userRoleQueryRepository = userRoleQueryRepository;
    }


    #region Query
    public async Task<List<UserRoleAuthDto>> GetRolesByUserAsync(Guid userGuid) {
        var query = _userRoleQueryRepository.GetQuery(true);
        var userRoles = await query
            .Include(x => x.Role)
            .Include(x => x.User)
            .Where(x => x.UserId == userGuid)
            .Select(x => new UserRoleAuthDto() {
                UserName = x.User.Username,
                RoleName = x.Role.Name,
                UserId = x.UserId,
                RoleId = x.RoleId
            })
            .ToListAsync();

        userRoles ??= new();
        return userRoles;
    }

    #endregion

    #region Command
    public async Task RemoveRoleAsync(Guid roleGuid) {
        var usedRoles = await _userRoleQueryRepository.GetByFilterAsync(x => x.RoleId == roleGuid);
        if (usedRoles == null) {
            var role = await _roleQueryRepository.GetByIdAsync(roleGuid.ToString());
            _roleCommandRepository.Remove(role);
            await _roleCommandRepository.SaveAsync();
        }

    }


    public async Task AddRoleAsync(string roleName) {
        var role = _roleQueryRepository.GetByFilterAsync(x => x.Name == roleName);

        if (role == null) {
            await _roleCommandRepository.CreateAsync(new ApplicationRole() {
                Name = roleName
            });
            await _roleCommandRepository.SaveAsync();
        }
    }


    public async Task AssignRoleByUserAsync(Guid userGuid, Guid roleGuid) {
        await _userRoleCommandRepository.CreateAsync(new ApplicationUserRole() {
            RoleId = roleGuid,
            UserId = userGuid
        });
        await _userRoleCommandRepository.SaveAsync();
    }


    public async Task AssignRoleRangeByUserAsync(Guid userGuid, List<Guid> roles) {
        if (roles == null || roles.Count == 0) {
            return;
        }
        var userRoles = await _userRoleQueryRepository.GetAllByFilterAsync(x => x.UserId == userGuid && x.RoleId != RoleDefaults.SuperUser.Id);
        _userRoleCommandRepository.RemoveRange(userRoles);
        await _userRoleCommandRepository.SaveAsync();

        List<ApplicationUserRole> userRoleAssignList = new();
        foreach (var roleId in roles) {
            if (roleId == RoleDefaults.SuperUser.Id) {
                continue;
            }
            userRoleAssignList.Add(new ApplicationUserRole() {
                RoleId = roleId,
                UserId = userGuid
            });
        }

        if (userRoleAssignList.Count > 0) {
            await _userRoleCommandRepository.CreateRangeAsync(userRoleAssignList);
            await _userRoleCommandRepository.SaveAsync();
        }
    }


    public async Task UnAssignRoleByUserAsync(Guid userGuid, Guid roleGuid) {
        //TODO Kullanıcı bu role sahipse bu rolü kaldır.
        var userRoleEntity = await _userRoleQueryRepository.GetAllByFilterAsync(x => x.UserId == userGuid);
        var targetUserRoleEntity = userRoleEntity.SingleOrDefault(x => x.RoleId == roleGuid);
        if (targetUserRoleEntity != null) {
            _userRoleCommandRepository.Remove(targetUserRoleEntity);
            await _userRoleCommandRepository.SaveAsync();
        }

    }
    #endregion

}
