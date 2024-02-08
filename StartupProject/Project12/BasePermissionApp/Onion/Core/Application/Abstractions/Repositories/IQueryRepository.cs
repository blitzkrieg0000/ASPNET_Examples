using System.Linq.Expressions;
using Application.Abstractions.Repository;
using Domain.Entities;

namespace Application.Abstractions;


public interface IQueryRepository<T> : IRepository<T> where T : BaseEntity {

    IQueryable<T> GetQuery(bool asNoTracking = true);

    Task<int> GetCountAsync();

    Task<int> GetCountAsync(Expression<Func<T, bool>> filter, bool tracking = false);

    Task<T> GetByIdAsync(string id, bool asNoTracking = true);

    Task<T> GetByIdAsync(Guid id, bool asNoTracking = true);

    Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter, bool asNoTracking = true);

    Task<List<T>> GetAllAsync(bool asNoTracking = true);

    Task<List<T>> GetRangeAsync(int skip, int range, bool asNoTracking = true);

    Task<List<T>> GetRangeAsync(int skip, int range, Expression<Func<T, bool>> filter, bool asNoTracking = true);

    Task<List<T>> GetAllByFilterAsync(Expression<Func<T, bool>> filter, bool asNoTracking = true);

}
