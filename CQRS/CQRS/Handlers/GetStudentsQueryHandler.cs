using CQRS.CQRS.Queries;
using CQRS.CQRS.Results;
using CQRS.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS.CQRS.Handlers {
    public class GetStudentsQueryHandler : IRequestHandler<GetStudentsQuery, IEnumerable<GetStudentsQueryResult>> {
        private readonly MainContext context;

        public GetStudentsQueryHandler(MainContext context) {
            this.context = context;
        }

        public async Task<IEnumerable<GetStudentsQueryResult>> Handle(GetStudentsQuery request, CancellationToken cancellationToken) {
            return await this.context.Students
            .Select(x => new GetStudentsQueryResult() {
                Name = x.Name,
                Surname = x.Surname
            })
            .AsNoTracking()
            .ToListAsync(cancellationToken: cancellationToken);
        }
    }
}