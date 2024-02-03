using Application.Interfaces.Repository.Role;
using Domain.Entities.Auth;
using Persistence.Contexts;

namespace Persistence.Repositories.Role;
public class RoleQueryRepository : QueryRepository<ApplicationRole>, IRoleQueryRepository {
    public RoleQueryRepository(DefaultContext context) : base(context) {

    }
}
