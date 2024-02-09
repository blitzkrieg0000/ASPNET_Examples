using UI.Abstraction.Repository.User;
using UI.Contexts;
using UI.Entities.Auth;

namespace UI.Repositories.User;


public class UserCommandRepository(DefaultContext context) : CommandRepository<ApplicationUser>(context), IUserCommandRepository {

}
