using System.Linq.Expressions;
using Domain.Entities.Auth;

namespace Application.Abstractions.Repository.UserRole;


public interface IUserRoleQueryRepository : IQueryRepository<ApplicationUserRole> {

    Task<List<ApplicationUserRole>> GetRangePagedListWithRelationsAsync(int page, int range, Expression<Func<ApplicationUserRole, bool>> filter);

}
