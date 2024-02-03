using MediatR;

namespace Application.Features.CQRS.Commands.User.RemoveUser;


public class RemoveUserCommandRequest : IRequest<RemoveUserCommandResponse> {
    public Guid Id { get; set; }
}
