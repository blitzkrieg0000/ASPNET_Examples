using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Models.Auth;
using MediatR;

namespace Application.Features.CQRS.Queries.Auth.ResetPassword;

public class ResetPasswordRequest : IRequest<ResetPasswordResponse> {
    public ResetPasswordModel resetPasswordModel;

    public ResetPasswordRequest(ResetPasswordModel resetPasswordModel) {
        this.resetPasswordModel = resetPasswordModel;
    }
}
