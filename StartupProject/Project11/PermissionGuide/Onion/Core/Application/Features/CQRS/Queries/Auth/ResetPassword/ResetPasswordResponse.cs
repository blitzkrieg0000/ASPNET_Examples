using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.ResponseObjects;

namespace Application.Features.CQRS.Queries.Auth.ResetPassword;

public class ResetPasswordResponse : Response {
    public ResetPasswordResponse(ResponseType responseType) : base(responseType) {
    }

    public ResetPasswordResponse(ResponseType responseType, string message) : base(responseType, message) {
    }
}
