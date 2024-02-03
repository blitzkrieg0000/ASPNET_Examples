using Application.Interfaces.Service.Auth;
using MediatR;

namespace Application.Features.CQRS.Commands.Auth.ApiRefreshTokenSignIn;


public class ApiRefreshTokenSignInHandler : IRequestHandler<ApiRefreshTokenSignInRequest, ApiRefreshTokenSignInResponse> {
    private readonly ICustomAuthService _customAuthService;

    public ApiRefreshTokenSignInHandler(ICustomAuthService customAuthService) {
        _customAuthService = customAuthService;
    }


    public async Task<ApiRefreshTokenSignInResponse> Handle(ApiRefreshTokenSignInRequest request, CancellationToken cancellationToken) {
        var response = await _customAuthService.ApiRefreshTokenSignInAsync(request.RefreshToken);
        return new(response.ResponseType, response.Data, response.Message);
    }
}
