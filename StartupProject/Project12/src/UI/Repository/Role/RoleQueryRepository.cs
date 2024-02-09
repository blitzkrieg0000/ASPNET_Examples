using UI.Abstraction.Repository.Role;
using UI.Contexts;
using UI.Entities.Auth;

namespace UI.Repositories.Role;


public class RoleQueryRepository(DefaultContext context) : QueryRepository<ApplicationRole>(context), IRoleQueryRepository {

}
