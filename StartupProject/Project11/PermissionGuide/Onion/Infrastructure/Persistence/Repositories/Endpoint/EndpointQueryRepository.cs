using Application.Interfaces.Repository.Endpoint;
using Domain.Entities.Auth;
using Persistence.Contexts;

namespace Persistence.Repositories.Endpoint;


public class EndpointQueryRepository : QueryRepository<ApplicationEndpoint>, IEndpointQueryRepository {
    public EndpointQueryRepository(DefaultContext context) : base(context) {
    }
}

