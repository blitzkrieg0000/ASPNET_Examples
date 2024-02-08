using System.Linq.Expressions;
using Application.Abstractions.Repository.UserRole;
using Domain.Entities.Auth;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repositories.UserRole;


public class UserRoleQueryRepository : QueryRepository<ApplicationUserRole>, IUserRoleQueryRepository {
    public UserRoleQueryRepository(DefaultContext context) : base(context) {
    }

    public async Task<List<ApplicationUserRole>> GetRangePagedListWithRelationsAsync(int page, int range, Expression<Func<ApplicationUserRole, bool>> filter) {
        return await Table.AsNoTracking()
        .Where(filter)
        .OrderBy(x => x.Id)
        .Include(x => x.User)
        .ThenInclude(x => x.ApplicationUserClaims)
        .ToListAsync();
    }

}