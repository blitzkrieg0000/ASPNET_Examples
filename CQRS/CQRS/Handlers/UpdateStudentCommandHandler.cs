using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRS.CQRS.Commands;
using CQRS.Data;
using MediatR;

namespace CQRS.CQRS.Handlers {
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand> {
        private readonly MainContext _context;

        public UpdateStudentCommandHandler(MainContext context) {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateStudentCommand request, CancellationToken cancellationToken) {
            var updatedStudent = await _context.Students.FindAsync(request.Id);
            updatedStudent.Age = request.Age;
            updatedStudent.Name = request.Name;
            updatedStudent.Surname = request.Surname;
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}