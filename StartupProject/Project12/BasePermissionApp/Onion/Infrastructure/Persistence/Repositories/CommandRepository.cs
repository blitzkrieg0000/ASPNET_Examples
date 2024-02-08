using Application.Abstractions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using Persistence.Contexts;

namespace Persistence.Repositories;


public class CommandRepository<T> : ICommandRepository<T> where T : BaseEntity {
    private IDbContextTransaction _transaction = null!;
    private readonly DefaultContext _context;

    public CommandRepository(DefaultContext context) {
        _context = context;

        // var strategy = context.Database.CreateExecutionStrategy();
        // strategy.Execute(async () => {
        //     await this.SaveAsync();
        //     await _transaction.CommitAsync();
        // });
    }

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
    public async Task<bool> CommitAsync(bool state = true) {
        await SaveAsync();
        if (_transaction != null) {
            if (state) {
                await _transaction.CommitAsync();
            } else {
                await _transaction.RollbackAsync();
            }

            await DisposeAsync();
            return true;
        }
        return false;
    }


    public async ValueTask DisposeAsync() {
        await _context.DisposeAsync();
        GC.SuppressFinalize(this);
    }


}
