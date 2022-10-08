using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRS.CQRS.Commands;
using CQRS.Data;

namespace CQRS.CQRS.Handlers {
    public class RemoveStudentCommandHandler {
        private readonly MainContext _context;

        public RemoveStudentCommandHandler(MainContext context) {
            _context = context;
        }

        public void Handle(RemoveStudentCommand command) {
            var deletedEntity = _context.Students.Find(command.Id);
            _context.Students.Remove(deletedEntity);
            _context.SaveChanges();
        }
    }
}