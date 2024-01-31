using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRS.CQRS.Commands;
using CQRS.Data;
using MediatR;

namespace CQRS.CQRS.Handlers {
    public class RemoveStudentCommandHandler : IRequestHandler<RemoveStudentCommand> {
        private readonly MainContext _context;

        public RemoveStudentCommandHandler(MainContext context) {
            _context = context;
        }

        public async Task<Unit> Handle(RemoveStudentCommand request, CancellationToken cancellationToken) {
            
            var deletedEntity = await _context.Students.FindAsync(new object?[] { request.Id }, cancellationToken: cancellationToken);
            _context.Students.Remove(deletedEntity);
            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}