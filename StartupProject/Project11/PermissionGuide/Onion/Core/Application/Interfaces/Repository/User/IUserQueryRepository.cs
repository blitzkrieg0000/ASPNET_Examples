using System.Linq.Expressions;
using Domain.Entities.Auth;
using X.PagedList;

namespace Application.Interfaces.Repository.User;


public interface IUserQueryRepository : IQueryRepository<ApplicationUser> {

    Task<IPagedList<ApplicationUser>> GetRangePagedListWithRelationsAsync(int page, int range);

    Task<IPagedList<ApplicationUser>> GetRangePagedListWithRelationsAsync(int page, int range, Expression<Func<ApplicationUser, bool>> filter);

}
