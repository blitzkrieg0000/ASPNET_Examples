using CQRS.CQRS.Queries;
using CQRS.CQRS.Results;
using CQRS.Data;

namespace CQRS.CQRS.Handlers {

    public class GetStudentByIdQueryHandler {
        private readonly MainContext _context;

        public GetStudentByIdQueryHandler(MainContext context) {
            _context = context;
        }

        public GetStudentByIdQueryResult Handle(GetStudentByIdQuery query) {
            var student = _context.Set<Student>().Find(query.Id);
            
            return new GetStudentByIdQueryResult() {
                Age = student.Age,
                Name = student.Name,
                Surname = student.Surname
            };
        }
    }
    
}