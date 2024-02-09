using UI.Abstraction.Repository.User;
using UI.Contexts;
using UI.Entities.Auth;

namespace UI.Repositories.User;


public class UserQueryRepository(DefaultContext context) : QueryRepository<ApplicationUser>(context), IUserQueryRepository {

}
