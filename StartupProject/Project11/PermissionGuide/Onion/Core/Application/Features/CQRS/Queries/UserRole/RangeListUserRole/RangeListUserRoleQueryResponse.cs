using Application.Dtos.UserRole;
using Common.ResponseObjects;
using X.PagedList;

namespace Application.Features.CQRS.Queries.UserRole.RangeListUserRole;


public class RangeListUserRoleQueryResponse : Response<IPagedList<UserRoleDto>> {
    public RangeListUserRoleQueryResponse(ResponseType responseType) : base(responseType) {
    }

    public RangeListUserRoleQueryResponse(ResponseType responseType, string message) : base(responseType, message) {
    }

    public RangeListUserRoleQueryResponse(ResponseType responseType, IPagedList<UserRoleDto> data) : base(responseType, data) {
    }

    public RangeListUserRoleQueryResponse(ResponseType responseType, IPagedList<UserRoleDto> data, string message) : base(responseType, data, message) {
    }

    public RangeListUserRoleQueryResponse(ResponseType responseType, IPagedList<UserRoleDto> data, IDictionary<string, dynamic> metaData) : base(responseType, data, metaData) {
    }

    public RangeListUserRoleQueryResponse(ResponseType responseType, IPagedList<UserRoleDto> data, List<CustomValidationError> errors) : base(responseType, data, errors) {
    }

    public RangeListUserRoleQueryResponse(ResponseType responseType, IPagedList<UserRoleDto> data, IDictionary<string, dynamic> metaData, List<CustomValidationError> errors) : base(responseType, data, metaData, errors) {
    }
}
