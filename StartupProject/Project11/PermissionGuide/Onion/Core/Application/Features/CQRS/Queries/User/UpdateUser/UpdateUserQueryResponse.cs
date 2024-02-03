using Application.Dtos.User;
using Common.ResponseObjects;

namespace Application.Features.CQRS.Queries.User.UpdateUser;


public class UpdateUserQueryResponse : Response<UserUpdateDto> {
    public UpdateUserQueryResponse(ResponseType responseType) : base(responseType) {
    }

    public UpdateUserQueryResponse(ResponseType responseType, string message) : base(responseType, message) {
    }

    public UpdateUserQueryResponse(ResponseType responseType, UserUpdateDto data) : base(responseType, data) {
    }

    public UpdateUserQueryResponse(ResponseType responseType, UserUpdateDto data, string message) : base(responseType, data, message) {
    }

    public UpdateUserQueryResponse(ResponseType responseType, UserUpdateDto data, IDictionary<string, dynamic> metaData) : base(responseType, data, metaData) {
    }

    public UpdateUserQueryResponse(ResponseType responseType, UserUpdateDto data, List<CustomValidationError> errors) : base(responseType, data, errors) {
    }

    public UpdateUserQueryResponse(ResponseType responseType, UserUpdateDto data, IDictionary<string, dynamic> metaData, List<CustomValidationError> errors) : base(responseType, data, metaData, errors) {
    }
}
