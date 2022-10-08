using System.Collections.Generic;
using CQRS.CQRS.Results;
using MediatR;

namespace CQRS.CQRS.Queries {
    public class GetStudentsQuery : IRequest<IEnumerable<GetStudentsQueryResult>> {

    }
}