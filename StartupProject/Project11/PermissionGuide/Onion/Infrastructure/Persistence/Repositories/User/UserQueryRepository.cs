using System.Linq.Expressions;
using Application.Interfaces.Repository.User;
using Domain.Entities.Auth;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using X.PagedList;

namespace Persistence.Repositories.User;


public class UserQueryRepository : QueryRepository<ApplicationUser>, IUserQueryRepository {
    public UserQueryRepository(DefaultContext context) : base(context) {
    }

    public async Task<IPagedList<ApplicationUser>> GetRangePagedListWithRelationsAsync(int page, int range) {
        return await Table.AsNoTracking()
        .OrderBy(x => x.Id)
        .Include(x => x.ApplicationUserClaims)
        .Include(x => x.ApplicationUserRoles)
        .ThenInclude(x => x.Role)
        .ToPagedListAsync(page, range);
    }

    public async Task<IPagedList<ApplicationUser>> GetRangePagedListWithRelationsAsync(int page, int range, Expression<Func<ApplicationUser, bool>> filter) {
        return await Table.AsNoTracking()
        .OrderBy(x => x.Id)
        .Include(x => x.ApplicationUserClaims)
        .Include(x => x.ApplicationUserRoles)
        .ThenInclude(x => x.Role)
        .Where(filter)
        .ToPagedListAsync(page, range);
    }

}
