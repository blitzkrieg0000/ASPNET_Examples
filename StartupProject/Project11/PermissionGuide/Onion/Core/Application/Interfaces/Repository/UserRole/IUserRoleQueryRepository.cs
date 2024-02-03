using System.Linq.Expressions;
using Domain.Entities.Auth;
using X.PagedList;

namespace Application.Interfaces.Repository.UserRole;


public interface IUserRoleQueryRepository : IQueryRepository<ApplicationUserRole> {

    Task<IPagedList<ApplicationUserRole>> GetRangePagedListWithRelationsAsync(int page, int range, Expression<Func<ApplicationUserRole, bool>> filter);

}
