using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using UI.Entities.Concrete;

namespace DataAccess.Repositories {
    public class Repository<T> : IRepository<T> where T : BaseEntity {
        // Sadece Database İşlemleri Yapılıyor

        private readonly TennisContext _context;
        public Repository(TennisContext context) {
            _context = context;
        }

        public IQueryable<T> GetQuery() {
            return _context.Set<T>().AsQueryable();
        }

        public async Task<List<T>> GetAll() {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> Find(object id) {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> GetListByFilter(Expression<Func<T, bool>> filter, bool asNoTracking = false) {
            return asNoTracking ?
                await _context.Set<T>().Where(filter).ToListAsync() :
                await _context.Set<T>().AsNoTracking().Where(filter).ToListAsync();
        }

        public async Task<T> GetByFilter(Expression<Func<T, bool>> filter, bool asNoTracking = false) {
            return asNoTracking ?
                await _context.Set<T>().SingleOrDefaultAsync(filter) :
                await _context.Set<T>().AsNoTracking().SingleOrDefaultAsync(filter);
        }

        public async Task Create(T entity) {
            await _context.Set<T>().AddAsync(entity);
        }

        public void Remove(T entity) {
            _context.Set<T>().Remove(entity);
        }

        public void Update(T entity, T unchanged) {
            _context.Entry(unchanged).CurrentValues.SetValues(entity);
        }


    }
}