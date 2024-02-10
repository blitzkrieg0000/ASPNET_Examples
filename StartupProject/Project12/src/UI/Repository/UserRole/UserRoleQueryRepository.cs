using UI.Abstraction.Repository.UserRole;
using UI.Contexts;
using UI.Entities.Auth;
using UI.Repositories;

namespace UI.Repository.UserRole;


public class UserRoleQueryRepository : QueryRepository<ApplicationUserRole>, IUserRoleQueryRepository {
    public UserRoleQueryRepository(DefaultContext context) : base(context) {
    }

}