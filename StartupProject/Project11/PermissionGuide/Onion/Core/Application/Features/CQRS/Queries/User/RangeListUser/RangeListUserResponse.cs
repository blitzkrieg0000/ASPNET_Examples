using Application.Models.User;
using Common.ResponseObjects;
using X.PagedList;

namespace Application.Features.CQRS.Queries.User.RangeListUser;


public class RangeListUserResponse : Response<IPagedList<UserViewModel>> {
    public RangeListUserResponse(ResponseType responseType) : base(responseType) {
    }

    public RangeListUserResponse(ResponseType responseType, string message) : base(responseType, message) {
    }

    public RangeListUserResponse(ResponseType responseType, IPagedList<UserViewModel> data) : base(responseType, data) {
    }

    public RangeListUserResponse(ResponseType responseType, IPagedList<UserViewModel> data, string message) : base(responseType, data, message) {
    }

    public RangeListUserResponse(ResponseType responseType, IPagedList<UserViewModel> data, IDictionary<string, dynamic> metaData) : base(responseType, data, metaData) {
    }

    public RangeListUserResponse(ResponseType responseType, IPagedList<UserViewModel> data, List<CustomValidationError> errors) : base(responseType, data, errors) {
    }

    public RangeListUserResponse(ResponseType responseType, IPagedList<UserViewModel> data, IDictionary<string, dynamic> metaData, List<CustomValidationError> errors) : base(responseType, data, metaData, errors) {
    }
}
