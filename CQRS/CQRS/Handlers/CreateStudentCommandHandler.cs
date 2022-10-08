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
            await _context.Students.AddAsync(new Student() {
                Age = request.Age,
                Name = request.Name,
                Surname = request.Surname
            }, cancellationToken:cancellationToken);
            await _context.SaveChangesAsync(cancellationToken:cancellationToken);
            return Unit.Value;
        }
    }
}