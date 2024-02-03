using Application.Dtos.User;
using Common.ResponseObjects;

namespace Application.Features.CQRS.Queries.User.ListUser;


public class ListUserResponse : Response<List<UserDto>> {
    public ListUserResponse(ResponseType responseType) : base(responseType) {
    }

    public ListUserResponse(ResponseType responseType, string message) : base(responseType, message) {
    }

    public ListUserResponse(ResponseType responseType, List<UserDto> data) : base(responseType, data) {
    }

    public ListUserResponse(ResponseType responseType, List<UserDto> data, string message) : base(responseType, data, message) {
    }

    public ListUserResponse(ResponseType responseType, List<UserDto> data, IDictionary<string, dynamic> metaData) : base(responseType, data, metaData) {
    }

    public ListUserResponse(ResponseType responseType, List<UserDto> data, List<CustomValidationError> errors) : base(responseType, data, errors) {
    }

    public ListUserResponse(ResponseType responseType, List<UserDto> data, IDictionary<string, dynamic> metaData, List<CustomValidationError> errors) : base(responseType, data, metaData, errors) {
    }
}
