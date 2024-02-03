using Application.Dtos.Auth;
using Common.ResponseObjects;

namespace Application.Features.CQRS.Commands.Auth.SignUp;


public class SignUpResponse : Response<UserSignUpDto> {
    public SignUpResponse(ResponseType responseType) : base(responseType) {
    }

    public SignUpResponse(ResponseType responseType, string message) : base(responseType, message) {
    }

    public SignUpResponse(ResponseType responseType, UserSignUpDto data) : base(responseType, data) {
    }

    public SignUpResponse(ResponseType responseType, UserSignUpDto data, string message) : base(responseType, data, message) {
    }

    public SignUpResponse(ResponseType responseType, UserSignUpDto data, IDictionary<string, dynamic> metaData) : base(responseType, data, metaData) {
    }

    public SignUpResponse(ResponseType responseType, UserSignUpDto data, List<CustomValidationError> errors) : base(responseType, data, errors) {
    }

    public SignUpResponse(ResponseType responseType, UserSignUpDto data, IDictionary<string, dynamic> metaData, List<CustomValidationError> errors) : base(responseType, data, metaData, errors) {
    }
}
