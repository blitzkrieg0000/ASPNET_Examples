using Application.Interfaces.Repository.UserRole;
using Domain.Entities.Auth;
using Persistence.Contexts;

namespace Persistence.Repositories.UserRole;


public class UserRoleCommandRepository : CommandRepository<ApplicationUserRole>, IUserRoleCommandRepository {
    public UserRoleCommandRepository(DefaultContext context) : base(context) {
    }
}
