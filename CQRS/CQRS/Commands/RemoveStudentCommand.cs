namespace CQRS.CQRS.Commands {
    public class RemoveStudentCommand {
        public int Id { get; set; }

        public RemoveStudentCommand(int id) {
            Id = id;
        }
    }
}