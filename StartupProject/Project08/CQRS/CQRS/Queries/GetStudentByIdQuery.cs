using CQRS.CQRS.Results;
using MediatR;

namespace CQRS.CQRS.Queries {
    public class GetStudentByIdQuery : IRequest<GetStudentByIdQueryResult> {
        public int Id { get; set; }
        
        public GetStudentByIdQuery(int id) {
            Id = id;
        }

    }
}