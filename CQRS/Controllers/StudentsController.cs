using CQRS.CQRS.Commands;
using CQRS.CQRS.Handlers;
using CQRS.CQRS.Queries;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase {

        private readonly GetStudentByIdQueryHandler getStudentByIdQueryHandler;
        private readonly GetStudentsQueryHandler getStudentsQueryHandler;
        private readonly CreateStudentCommandHandler createStudentCommandHandler;
        private readonly RemoveStudentCommandHandler removeStudentCommandHandler;

        public StudentsController(GetStudentByIdQueryHandler getStudentByIdQueryHandler, GetStudentsQueryHandler getStudentsQueryHandler, CreateStudentCommandHandler createStudentCommandHandler, RemoveStudentCommandHandler removeStudentCommandHandler) {
            this.getStudentByIdQueryHandler = getStudentByIdQueryHandler;
            this.getStudentsQueryHandler = getStudentsQueryHandler;
            this.createStudentCommandHandler = createStudentCommandHandler;
            this.removeStudentCommandHandler = removeStudentCommandHandler;
        }

        [HttpGet("{id}")]
        public IActionResult GetStudent(int id) {
            var result = this.getStudentByIdQueryHandler.Handle(new GetStudentByIdQuery(id));
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAllStudent() {
            var result = this.getStudentsQueryHandler.Handle(new GetStudentsQuery());
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create(CreateStudentCommand command) {
            this.createStudentCommandHandler.Handle(command);
            return Created("", command.Name);
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id) {
            this.removeStudentCommandHandler.Handle(new RemoveStudentCommand(id));
            return NoContent();
        }

    }

}