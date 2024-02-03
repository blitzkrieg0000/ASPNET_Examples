using Application.Interfaces.Repository.Menu;
using Domain.Entities.Auth;
using Persistence.Contexts;

namespace Persistence.Repositories.Menu;


public class MenuQueryRepository : QueryRepository<ApplicationMenu>, IMenuQueryRepository {
    public MenuQueryRepository(DefaultContext context) : base(context) {
    }
}

