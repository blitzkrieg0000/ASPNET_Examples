using Application.Interfaces.Service.Auth;
using MediatR;

namespace Application.Features.CQRS.Commands.Auth.RefreshTokenSignIn;


public class RefreshTokenSignInHandler : IRequestHandler<RefreshTokenSignInRequest, RefreshTokenSignInResponse> {

    private readonly ICustomAuthService _customAuthService;

    public RefreshTokenSignInHandler(ICustomAuthService customAuthService) {
        _customAuthService = customAuthService;
    }

    public async Task<RefreshTokenSignInResponse> Handle(RefreshTokenSignInRequest request, CancellationToken cancellationToken) {
        var response = await _customAuthService.RefreshTokenSignInAsync(request.RefreshToken);
        return new(response.ResponseType, response.Data, response.Message);
    }
}
