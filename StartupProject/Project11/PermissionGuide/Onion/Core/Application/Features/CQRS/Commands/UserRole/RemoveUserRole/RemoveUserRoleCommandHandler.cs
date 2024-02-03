using Application.Interfaces.Repository.UserRole;
using Common.ResponseObjects;
using MediatR;

namespace Application.Features.CQRS.Commands.UserRole.RemoveUserRole;


public class RemoveUserRoleCommandHandler : IRequestHandler<RemoveUserRoleCommandRequest, RemoveUserRoleCommandResponse> {
    private readonly IUserRoleQueryRepository _userRoleQueryRepository;
    private readonly IUserRoleCommandRepository _userRoleCommandRepository;

    public RemoveUserRoleCommandHandler(IUserRoleQueryRepository userRoleQueryRepository, IUserRoleCommandRepository userRoleCommandRepository) {
        _userRoleQueryRepository = userRoleQueryRepository;
        _userRoleCommandRepository = userRoleCommandRepository;
    }

    public async Task<RemoveUserRoleCommandResponse> Handle(RemoveUserRoleCommandRequest request, CancellationToken cancellationToken) {
        var entity = await _userRoleQueryRepository.GetByFilterAsync(x => x.UserId == request.Model.UserId && x.RoleId == request.Model.RoleId);
        if (entity is not null) {
            if (entity.IsPersistent == true) {
                return new(ResponseType.NotAllowed, "Sistem tanımlı roller silinemez.");
            }
            _userRoleCommandRepository.Remove(entity);
            await _userRoleCommandRepository.SaveAsync();
            return new(ResponseType.Success, $"Rol ataması kaldırıldı.");
        }

        return new(ResponseType.NotAllowed, "Böyle bir rol ataması mevcut değil");
    }
}
