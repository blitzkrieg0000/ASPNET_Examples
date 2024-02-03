using Application.Models.Auth;
using MediatR;

namespace Application.Features.CQRS.Commands.Auth.UpdatePassword;


public class UpdatePasswordRequest : IRequest<UpdatePasswordResponse> {
    public UpdatePasswordModel UpdatePasswordModel { get; set; }

    public UpdatePasswordRequest(UpdatePasswordModel model) {
        UpdatePasswordModel = model;
    }
}
