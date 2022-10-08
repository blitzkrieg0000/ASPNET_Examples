using CQRS.CQRS.Results;
using MediatR;

namespace CQRS.CQRS.Queries {
    public class GetStudentByIdQuery : IRequest<GetStudentByIdQueryResult> {
        public GetStudentByIdQuery(int id) {
            Id = id;
        }
        public int Id { get; set; }
    }
}