using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TennisWeb6.Core.Application.Interfaces;
using TennisWeb6.Persistance.Context;

namespace TennisWeb6.Persistance.Repositories {
    public class Repository<T> : IRepository<T> where T : class, new() {
        private readonly MainContext context;

        public Repository(MainContext context) {
            this.context = context;
        }

        public async Task CreateAsync(T entity) {
            await this.context.Set<T>().AddAsync(entity);
            await this.context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync() {
            return await this.context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T?> GetByFilterAsync(Expression<Func<T, bool>> filter) {
            return await this.context.Set<T>().AsNoTracking().SingleOrDefaultAsync(filter);
        }

        public async Task<T?> GetByIdAsync(object id) {
            return await this.context.Set<T>().FindAsync(id);
        }

        public async Task RemoveAsync(T entity) {
            this.context.Set<T>().Remove(entity);
            await this.context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity) {
            this.context.Set<T>().Update(entity);
            await this.context.SaveChangesAsync();
        }
    }
}