using Domain.Entities;


namespace Application.Interfaces.Repository;


public interface ICommandRepository<T> : IRepository<T>, IUnitOfWork where T : BaseEntity {

    IQueryable<T> GetQuery(bool tracking = true);

    Task<Guid> CreateAsync(T entity);

    Task<bool> CreateRangeAsync(List<T> entity);

    void Update(T entity, T unchanged);

    Task UpdateAsync(T entity);

    bool UpdateOverwrite(T entity);

    void Remove(T entity);

    bool RemoveRange(List<T> entity);

    Task<int> SaveAsync();

}
