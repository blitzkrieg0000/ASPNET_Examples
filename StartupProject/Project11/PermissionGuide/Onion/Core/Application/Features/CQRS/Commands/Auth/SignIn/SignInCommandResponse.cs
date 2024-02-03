using Application.Dtos.Token;
using Common.ResponseObjects;

namespace Application.Features.CQRS.Commands.Auth.SignIn;


public class SignInCommandResponse : Response<TokenDto> {
    public SignInCommandResponse(ResponseType responseType) : base(responseType) {
    }

    public SignInCommandResponse(ResponseType responseType, string message) : base(responseType, message) {
    }

    public SignInCommandResponse(ResponseType responseType, TokenDto data) : base(responseType, data) {
    }

    public SignInCommandResponse(ResponseType responseType, TokenDto data, string message) : base(responseType, data, message) {
    }

    public SignInCommandResponse(ResponseType responseType, TokenDto data, IDictionary<string, dynamic> metaData) : base(responseType, data, metaData) {
    }

    public SignInCommandResponse(ResponseType responseType, TokenDto data, List<CustomValidationError> errors) : base(responseType, data, errors) {
    }

    public SignInCommandResponse(ResponseType responseType, TokenDto data, IDictionary<string, dynamic> metaData, List<CustomValidationError> errors) : base(responseType, data, metaData, errors) {
    }
}
