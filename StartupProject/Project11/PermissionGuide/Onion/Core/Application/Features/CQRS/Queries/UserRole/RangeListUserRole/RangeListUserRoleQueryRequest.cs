using System.Linq.Expressions;
using Application.Models.Paginator;
using Domain.Entities.Auth;
using MediatR;

namespace Application.Features.CQRS.Queries.UserRole.RangeListUserRole;


public class RangeListUserRoleQueryRequest : IRequest<RangeListUserRoleQueryResponse> {
    public PaginatorModel PaginatorModel;
    public Expression<Func<ApplicationUserRole, bool>>? Filter;

    public RangeListUserRoleQueryRequest(PaginatorModel paginatorModel) {
        PaginatorModel = paginatorModel;
    }
}
