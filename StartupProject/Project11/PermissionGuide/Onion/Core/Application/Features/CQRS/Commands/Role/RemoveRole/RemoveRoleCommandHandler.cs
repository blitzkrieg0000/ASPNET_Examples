using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.Repository.Role;
using Common.ResponseObjects;
using MediatR;

namespace Application.Features.CQRS.Commands.Role.RemoveRole;

public class RemoveRoleCommandHandler : IRequestHandler<RemoveRoleCommandRequest, RemoveRoleCommandResponse> {
    private readonly IRoleQueryRepository _roleQueryRepository;
    private readonly IRoleCommandRepository _roleCommandRepository;

    public RemoveRoleCommandHandler(IRoleQueryRepository roleQueryRepository, IRoleCommandRepository roleCommandRepository) {
        _roleQueryRepository = roleQueryRepository;
        _roleCommandRepository = roleCommandRepository;
    }

    public async Task<RemoveRoleCommandResponse> Handle(RemoveRoleCommandRequest request, CancellationToken cancellationToken) {
        var entity = await _roleQueryRepository.GetByIdAsync(request.Id);
        if (entity == null) {
            return new(ResponseType.NotAllowed, $"Silinecek rol bulunamadı.");
        }
        if (entity.IsPersistent == false) {
            _roleCommandRepository.Remove(entity);
            try {
                await _roleCommandRepository.SaveAsync();
            } catch {
                return new(ResponseType.Success, $"'{entity?.Name}' rolü kullanımdayken kaldırılamaz.");
            }
            return new(ResponseType.Success, $"'{entity?.Name}' rolü kaldırıldı.");
        } else {
            return new(ResponseType.NotAllowed, "Rol sistem tanımlı olduğundan kaldırılamıyor.");
        }

    }

}
