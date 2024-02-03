using MediatR;

namespace Application.Features.CQRS.Commands.Auth.ApiRefreshTokenSignIn;


public class ApiRefreshTokenSignInRequest : IRequest<ApiRefreshTokenSignInResponse> {
    public string? RefreshToken { get; set; }
}
