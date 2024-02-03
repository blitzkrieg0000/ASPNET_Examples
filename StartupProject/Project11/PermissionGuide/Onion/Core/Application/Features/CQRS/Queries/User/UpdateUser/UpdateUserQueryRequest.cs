using MediatR;

namespace Application.Features.CQRS.Queries.User.UpdateUser;


public class UpdateUserQueryRequest : IRequest<UpdateUserQueryResponse> {
    public Guid Id { get; set; }
}
