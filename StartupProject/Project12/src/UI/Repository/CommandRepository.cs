using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using UI.Abstraction.Repository;
using UI.Contexts;
using UI.Entity;

namespace UI.Repositories;


public class CommandRepository<T>(DefaultContext context) : ICommandRepository<T> where T : BaseEntity {
    private readonly DefaultContext _context = context;

    private IDbContextTransaction _transaction = null!;
    public DbSet<T> Table => _context.Set<T>();


    public async Task BeginTransactionAsync() {
        _transaction ??= await _context.Database.BeginTransactionAsync();
    }


    public IQueryable<T> GetQuery(bool asNoTracking = true) {
        var query = Table.AsQueryable();
        if (asNoTracking) {
            query = query.AsNoTracking();
        }
        return query;
    }


    public async Task<Guid> CreateAsync(T entity) {
        entity.Id = entity.Id == Guid.Empty ? Guid.NewGuid() : entity.Id;
        await Table.AddAsync(entity);
        return entity.Id;
    }


    public async Task<bool> CreateRangeAsync(List<T> entity) {
        await Table.AddRangeAsync(entity);
        return true;
    }


    public void Remove(T entity) {
        Table.Remove(entity);
    }


    public bool RemoveRange(List<T> entity) {
        Table.RemoveRange(entity);
        return true;
    }


    public void Update(T entity, T unchanged) {
        _context.Entry(unchanged).CurrentValues.SetValues(entity);
    }


    public async Task UpdateAsync(T entity) {
        var unchanged = await Table.FindAsync(entity.Id);
        if (unchanged != null) {
            this.Update(entity, unchanged);
        }
    }


    public bool UpdateOverwrite(T entity) {
        EntityEntry entityEntry = Table.Update(entity);
        return entityEntry.State == EntityState.Modified;
    }


    public async Task<int> SaveAsync() {
        return await _context.SaveChangesAsync();
    }


    //! UNIT OF WORK
    public async Task<bool> CommitAsync(bool state = true, bool dispose = false) {
        //TODO DBContext içerisindeki state'e göre SaveAsync'i çalıştıran eventla birlikte kullanıldığında davranışını kontrol et.
        await SaveAsync();
        if (_transaction != null) {
            if (state) {
                await _transaction.CommitAsync();
            }
            else {
                await _transaction.RollbackAsync();
            }

            if (dispose) {
                await DisposeAsync();
            }

            return true;
        }
        return false;
    }


    public async ValueTask DisposeAsync() {
        if (_transaction != null) {
            await _transaction.DisposeAsync();
            GC.SuppressFinalize(this);
        }
    }


}
