using Application.Interfaces.Service.Auth;
using Common.ResponseObjects;
using MediatR;

namespace Application.Features.CQRS.Commands.Auth.UpdatePassword;


public class UpdatePasswordHandler : IRequestHandler<UpdatePasswordRequest, UpdatePasswordResponse> {

    private readonly ICustomAuthService _customAuthService;

    public UpdatePasswordHandler(ICustomAuthService customAuthService) {
        _customAuthService = customAuthService;
    }

    public async Task<UpdatePasswordResponse> Handle(UpdatePasswordRequest request, CancellationToken cancellationToken) {

        var response = await _customAuthService.UpdatePasswordAsync(request.UpdatePasswordModel);

        return new(response.ResponseType, response.Message);
    }

}

