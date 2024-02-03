using Application.Interfaces.Repository.User;
using Domain.Entities.Auth;
using Persistence.Contexts;

namespace Persistence.Repositories.User;

public class UserCommandRepository : CommandRepository<ApplicationUser>, IUserCommandRepository {
    public UserCommandRepository(DefaultContext context) : base(context) {
    }
}
