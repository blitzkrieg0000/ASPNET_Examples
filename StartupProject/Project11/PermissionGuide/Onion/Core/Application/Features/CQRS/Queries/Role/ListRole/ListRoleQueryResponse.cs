using Application.Dtos.Role;
using Common.ResponseObjects;

namespace Application.Features.CQRS.Queries.Role.ListRole;


public class ListRoleQueryResponse : Response<List<RoleDto>> {
    public ListRoleQueryResponse(ResponseType responseType) : base(responseType) {
    }

    public ListRoleQueryResponse(ResponseType responseType, string message) : base(responseType, message) {
    }

    public ListRoleQueryResponse(ResponseType responseType, List<RoleDto> data) : base(responseType, data) {
    }

    public ListRoleQueryResponse(ResponseType responseType, List<RoleDto> data, string message) : base(responseType, data, message) {
    }

    public ListRoleQueryResponse(ResponseType responseType, List<RoleDto> data, IDictionary<string, dynamic> metaData) : base(responseType, data, metaData) {
    }

    public ListRoleQueryResponse(ResponseType responseType, List<RoleDto> data, List<CustomValidationError> errors) : base(responseType, data, errors) {
    }

    public ListRoleQueryResponse(ResponseType responseType, List<RoleDto> data, IDictionary<string, dynamic> metaData, List<CustomValidationError> errors) : base(responseType, data, metaData, errors) {
    }
}
