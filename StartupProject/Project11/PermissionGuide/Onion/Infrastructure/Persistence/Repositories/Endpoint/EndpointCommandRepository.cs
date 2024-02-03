using Application.Interfaces.Repository.Endpoint;
using Domain.Entities.Auth;
using Persistence.Contexts;

namespace Persistence.Repositories.Endpoint;


public class EndpointCommandRepository : CommandRepository<ApplicationEndpoint>, IEndpointCommandRepository {
    public EndpointCommandRepository(DefaultContext context) : base(context) {
    }
}

