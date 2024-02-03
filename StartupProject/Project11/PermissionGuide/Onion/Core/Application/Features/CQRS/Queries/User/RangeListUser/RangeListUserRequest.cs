using System.Linq.Expressions;
using Application.Models.Paginator;
using Domain.Entities.Auth;
using MediatR;

namespace Application.Features.CQRS.Queries.User.RangeListUser;


public class RangeListUserRequest : IRequest<RangeListUserResponse> {
    public PaginatorModel PaginatorModel { get; set; }
    public Expression<Func<ApplicationUser, bool>> Filter = x => true;

    public RangeListUserRequest(PaginatorModel paginatorModel) {
        PaginatorModel = paginatorModel;
    }
}
