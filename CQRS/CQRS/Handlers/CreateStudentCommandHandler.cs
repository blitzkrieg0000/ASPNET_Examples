using CQRS.CQRS.Commands;
using CQRS.Data;
using MediatR;

namespace CQRS.CQRS.Handlers {
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand> {
        private readonly MainContext _context;

        public CreateStudentCommandHandler(MainContext context) {
            _context = context;
        }


        public async Task<Unit> Handle(CreateStudentCommand request, CancellationToken cancellationToken) {
            _context.Students.AddRange(new Student() {
                Age = request.Age,
                Name = request.Name,
                Surname = request.Surname
            });
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}