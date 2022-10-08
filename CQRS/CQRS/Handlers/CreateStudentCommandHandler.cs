using CQRS.CQRS.Commands;
using CQRS.Data;

namespace CQRS.CQRS.Handlers {
    public class CreateStudentCommandHandler {
        private readonly MainContext _context;

        public CreateStudentCommandHandler(MainContext context) {
            _context = context;
        }

        public void Handle(CreateStudentCommand command) {
            _context.Students.AddRange(new Student() {
                Age = command.Age,
                Name = command.Name,
                Surname = command.Surname
            });
            _context.SaveChanges();
        }

    }
}