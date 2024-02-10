
using UI.Abstraction.Repository.UserRole;
using UI.Contexts;
using UI.Entities.Auth;
using UI.Repositories;

namespace UI.Repository.UserRole;


public class UserRoleCommandRepository : CommandRepository<ApplicationUserRole>, IUserRoleCommandRepository {
    public UserRoleCommandRepository(DefaultContext context) : base(context) {
    }
}
