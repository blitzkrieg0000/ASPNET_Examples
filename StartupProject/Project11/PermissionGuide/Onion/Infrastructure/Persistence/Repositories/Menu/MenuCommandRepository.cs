using Application.Interfaces.Repository.Menu;
using Domain.Entities.Auth;
using Persistence.Contexts;

namespace Persistence.Repositories.Menu;


public class MenuCommandRepository : CommandRepository<ApplicationMenu>, IMenuCommandRepository {
    public MenuCommandRepository(DefaultContext context) : base(context) {
    }
}

