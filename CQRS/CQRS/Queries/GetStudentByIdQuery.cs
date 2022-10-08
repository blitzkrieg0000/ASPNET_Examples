namespace CQRS.CQRS.Queries {
    public class GetStudentByIdQuery {
        public GetStudentByIdQuery(int id) {
            Id = id;
        }
        public int Id { get; set; }
    }
}