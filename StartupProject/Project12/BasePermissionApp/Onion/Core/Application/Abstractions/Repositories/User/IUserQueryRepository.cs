using System.Linq.Expressions;
using Domain.Entities.Auth;

namespace Application.Abstractions.Repository.User;


public interface IUserQueryRepository : IQueryRepository<ApplicationUser> {

    Task<List<ApplicationUser>> GetRangePagedListWithRelationsAsync();

    Task<List<ApplicationUser>> GetRangePagedListWithRelationsAsync(Expression<Func<ApplicationUser, bool>> filter);

}
