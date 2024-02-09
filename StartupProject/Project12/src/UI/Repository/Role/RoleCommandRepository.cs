using UI.Abstraction.Repository.Role;
using UI.Contexts;
using UI.Entities.Auth;

namespace UI.Repositories.Role;


public class RoleCommandRepository(DefaultContext context) : CommandRepository<ApplicationRole>(context), IRoleCommandRepository {

}
