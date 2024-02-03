using Application.Interfaces.Service.Auth;
using Application.Interfaces.Service.Hash;
using Common.ResponseObjects;
using MediatR;

namespace Application.Features.CQRS.Commands.Auth.ApiSignIn;


public class ApiSignInHandler : IRequestHandler<ApiSignInRequest, ApiSignInResponse> {
    private readonly ICustomAuthService _customAuthService;
    private readonly IHashService _hashService;

    public ApiSignInHandler(ICustomAuthService customAuthService, IHashService hashService) {
        _customAuthService = customAuthService;
        _hashService = hashService;
    }


    public async Task<ApiSignInResponse> Handle(ApiSignInRequest request, CancellationToken cancellationToken) {
        request.UserSignInDto.Password = _hashService.GetHashSha3_512(request.UserSignInDto.Password);
        var response = await _customAuthService.ApiSignInAsync(request.UserSignInDto);
        return new(response.ResponseType, response.Data, response.Message);
    }
}
