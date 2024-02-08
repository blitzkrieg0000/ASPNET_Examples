using System.Linq.Expressions;
using Application.Abstractions.Repository.User;
using Domain.Entities.Auth;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repositories.User;


public class UserQueryRepository : QueryRepository<ApplicationUser>, IUserQueryRepository {
    public UserQueryRepository(DefaultContext context) : base(context) {
    }

    public async Task<List<ApplicationUser>> GetRangePagedListWithRelationsAsync() {
        return await Table.AsNoTracking()
        .OrderBy(x => x.Id)
        .Include(x => x.ApplicationUserClaims)
        .Include(x => x.ApplicationUserRoles)
        .ThenInclude(x => x.Role)
        .ToListAsync();
    }

    public async Task<List<ApplicationUser>> GetRangePagedListWithRelationsAsync(Expression<Func<ApplicationUser, bool>> filter) {
        return await Table.AsNoTracking()
        .OrderBy(x => x.Id)
        .Include(x => x.ApplicationUserClaims)
        .Include(x => x.ApplicationUserRoles)
        .ThenInclude(x => x.Role)
        .Where(filter)
        .ToListAsync();
    }

}
