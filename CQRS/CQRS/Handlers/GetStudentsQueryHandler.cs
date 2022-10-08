using CQRS.CQRS.Queries;
using CQRS.CQRS.Results;
using CQRS.Data;
using Microsoft.EntityFrameworkCore;

namespace CQRS.CQRS.Handlers {
    public class GetStudentsQueryHandler {
        private readonly MainContext context;

        public GetStudentsQueryHandler(MainContext context) {
            this.context = context;
        }

        public IEnumerable<GetStudentsQueryResult> Handle(GetStudentsQuery query) {
            return this.context.Students
            .Select(x => new GetStudentsQueryResult() {
                Name = x.Name,
                Surname = x.Surname
            })
            .AsNoTracking().AsEnumerable();

        }
    }
}