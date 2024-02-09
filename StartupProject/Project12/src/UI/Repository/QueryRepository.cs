using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using UI.Abstraction.Repository;
using UI.Contexts;
using UI.Entity;


namespace UI.Repositories;


public class QueryRepository<T>(DefaultContext context) : IQueryRepository<T> where T : BaseEntity {
    private readonly DefaultContext _context = context;

    public DbSet<T> Table => _context.Set<T>();


    public IQueryable<T> GetQuery(bool asNoTracking = true) {
        var query = Table.AsQueryable();
        if (asNoTracking)
            query = query.AsNoTracking();
        return query;
    }


    public async Task<int> GetCountAsync() {
        // Tablodaki toplam veri sayısını döndürür.
        return await Table.AsNoTracking().CountAsync();
    }


    public async Task<int> GetCountAsync(Expression<Func<T, bool>> filter, bool tracking = false) {
        //Experimental: Tabloya ait filtredeki veri sayısı
        var query = Table.AsQueryable();
        if (!tracking) {
            query = query.AsNoTracking();
        }

        return await query.Where(filter).CountAsync();
    }


    public async Task<T> GetByIdAsync(string id, bool asNoTracking = true) {
        var query = Table.AsQueryable();
        if (asNoTracking) {
            query = query.AsNoTracking();
        }

        return await query.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
    }


    public async Task<T> GetByIdAsync(Guid id, bool asNoTracking = true) {
        return await GetByIdAsync(id.ToString(), asNoTracking);
    }


    public async Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter, bool asNoTracking = true) {
        var query = Table.AsQueryable();
        if (asNoTracking) {
            query = query.AsNoTracking();
        }

        return await query.FirstOrDefaultAsync(filter);
    }


    public async Task<List<T>> GetAllAsync(bool asNoTracking = true) {
        var query = Table.AsQueryable();
        if (asNoTracking) {
            query = query.AsNoTracking();
        }

        return await query.ToListAsync();
    }


    public async Task<List<T>> GetRangeAsync(int skip, int range, bool asNoTracking = true) {
        var query = Table.AsQueryable();
        if (asNoTracking) {
            query = query.AsNoTracking();
        }

        return await query.OrderBy(x => x.Id).Skip(skip).Take(range).ToListAsync();
    }


    public async Task<List<T>> GetRangeAsync(int skip, int range, Expression<Func<T, bool>> filter, bool asNoTracking = true) {
        var query = Table.AsQueryable();
        if (asNoTracking) {
            query = query.AsNoTracking();
        }
        query = query.Where(filter);
        return await query.OrderBy(x => x.Id).Skip(skip).Take(range).ToListAsync();
    }


    public async Task<List<T>> GetAllByFilterAsync(Expression<Func<T, bool>> filter, bool asNoTracking = true) {
        var query = Table.AsQueryable();
        if (asNoTracking) {
            query = query.AsNoTracking();
        }

        return await query.Where(filter).ToListAsync();
    }


}