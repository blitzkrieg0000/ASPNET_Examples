using Application.Interfaces.Service.Auth;
using Common.ResponseObjects;
using MediatR;


namespace Application.Features.CQRS.Commands.User.RemoveUser;

public class RemoveUserCommandHandler : IRequestHandler<RemoveUserCommandRequest, RemoveUserCommandResponse> {

    private readonly IUserManagerService _userManagerService;

    public RemoveUserCommandHandler(IUserManagerService userManagerService) {
        _userManagerService = userManagerService;
    }

    public async Task<RemoveUserCommandResponse> Handle(RemoveUserCommandRequest request, CancellationToken cancellationToken) {
        await _userManagerService.RemoveUserByIdAsync(request.Id);
        return new RemoveUserCommandResponse(ResponseType.Success, $"{request.Id} silindi.");
    }

}
