using Application.Interfaces.Repository.Role;
using Domain.Entities.Auth;
using Persistence.Contexts;

namespace Persistence.Repositories.Role;

public class RoleCommandRepository : CommandRepository<ApplicationRole>, IRoleCommandRepository {
    public RoleCommandRepository(DefaultContext context) : base(context) {

        
    }
}
