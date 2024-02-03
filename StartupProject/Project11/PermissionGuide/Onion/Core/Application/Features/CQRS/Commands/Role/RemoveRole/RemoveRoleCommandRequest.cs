using MediatR;

namespace Application.Features.CQRS.Commands.Role.RemoveRole;


public class RemoveRoleCommandRequest : IRequest<RemoveRoleCommandResponse> {
    public Guid Id { get; set; }
}
