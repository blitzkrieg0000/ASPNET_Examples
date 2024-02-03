using Application.Consts.Auth;
using Application.Interfaces.Repository.Role;
using Application.Interfaces.Repository.User;
using Application.Interfaces.Repository.UserRole;
using Common.ResponseObjects;
using MediatR;

namespace Application.Features.CQRS.Commands.UserRole.CreateUserRole;


public class CreateUserRoleCommandHandler : IRequestHandler<CreateUserRoleCommandRequest, CreateUserRoleCommandResponse> {
    private readonly IUserQueryRepository _userQueryRepository;
    private readonly IRoleQueryRepository _roleQueryRepository;
    private readonly IUserRoleQueryRepository _userRoleQueryRepository;
    private readonly IUserRoleCommandRepository _userRoleCommandRepository;

    public CreateUserRoleCommandHandler(IUserQueryRepository userQueryRepository, IRoleQueryRepository roleQueryRepository, IUserRoleQueryRepository userRoleQueryRepository, IUserRoleCommandRepository userRoleCommandRepository) {
        _userQueryRepository = userQueryRepository;
        _roleQueryRepository = roleQueryRepository;
        _userRoleQueryRepository = userRoleQueryRepository;
        _userRoleCommandRepository = userRoleCommandRepository;
    }


    public async Task<CreateUserRoleCommandResponse> Handle(CreateUserRoleCommandRequest request, CancellationToken cancellationToken) {
        if (request.Model.RoleId != null && request.Model.UserId != null) {
            
            if(RoleDefaults.SuperUser.Id == request.Model.RoleId){
                return new(ResponseType.NotAllowed, "SuperUser rolü kullanılamaz. Başka bir rol oluşturmayı deneyiniz.");
            }

            var role = await _roleQueryRepository.GetByFilterAsync(x => x.Id == request.Model.RoleId);
            var user = await _userQueryRepository.GetByFilterAsync(x => x.Id == request.Model.UserId);

            if (role is not null && user is not null) {
                var assignedRole = await _userRoleQueryRepository.GetByFilterAsync(x => x.Role == role && x.User == user);
                if (assignedRole is null) {
                    await _userRoleCommandRepository.CreateAsync(new() {
                        RoleId = role.Id,
                        UserId = user.Id,
                        Active = true,
                    });
                    try {
                        await _userRoleCommandRepository.SaveAsync();
                    } catch (System.Exception) {
                        return new(ResponseType.NotAllowed, $"İzin verilmiyor.");
                    }
                    return new(ResponseType.Success, $"'{user.Name}' kullanıcısına '{role.Name}' rolü atandı.");
                }

            }

        }

        return new(ResponseType.NotAllowed, "Rol veya Kullanıcı Hatalı");
    }
}
