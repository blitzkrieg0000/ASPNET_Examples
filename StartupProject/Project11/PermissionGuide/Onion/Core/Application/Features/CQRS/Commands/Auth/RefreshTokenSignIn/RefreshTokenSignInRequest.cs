using Application.Dtos.Token;
using Common.ResponseObjects;
using MediatR;

namespace Application.Features.CQRS.Commands.Auth.RefreshTokenSignIn;

public class RefreshTokenSignInRequest : IRequest<RefreshTokenSignInResponse> {
    public string? RefreshToken { get; set; }
}
