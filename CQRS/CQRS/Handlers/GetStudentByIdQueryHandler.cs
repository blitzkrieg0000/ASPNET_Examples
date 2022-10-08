using CQRS.CQRS.Queries;
using CQRS.CQRS.Results;
using CQRS.Data;
using MediatR;

namespace CQRS.CQRS.Handlers {

    public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, GetStudentByIdQueryResult> {
        private readonly MainContext _context;

        public GetStudentByIdQueryHandler(MainContext context) {
            _context = context;
        }

        public async Task<GetStudentByIdQueryResult> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken) {
            var student = await _context.Set<Student>().FindAsync(request.Id);

            return new GetStudentByIdQueryResult() {
                Age = student.Age,
                Name = student.Name,
                Surname = student.Surname
            };
        }

        // public GetStudentByIdQueryResult Handle(GetStudentByIdQuery query) {
        //     var student = _context.Set<Student>().Find(query.Id);

        //     return new GetStudentByIdQueryResult() {
        //         Age = student.Age,
        //         Name = student.Name,
        //         Surname = student.Surname
        //     };
        // }
    }

}