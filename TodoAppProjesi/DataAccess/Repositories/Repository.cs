using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DataAccess.Contexts;
using DataAccess.Interfaces;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories {
    public class Repository<T> : IRepository<T> where T : BaseEntity {

        private readonly TodoContext _context;
        public Repository(TodoContext context) {
            _context = context;
        }

        public async Task<T> GetByFilter(Expression<Func<T, bool>> filter, bool asNoTracking = false) {
            return asNoTracking ?
                await _context.Set<T>().SingleOrDefaultAsync(filter) :
                await _context.Set<T>().AsNoTracking().SingleOrDefaultAsync(filter);
        }

        public async Task<T> GetById(object id) {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> GetAll() {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task Create(T entity) {
            await _context.Set<T>().AddAsync(entity);
        }

        public IQueryable<T> GetQuery() {
            return _context.Set<T>().AsQueryable();
        }

        public void Remove(object id) {
            var deletedEntity = _context.Set<T>().Find(id);
            _context.Set<T>().Remove(deletedEntity);
        }

        public void Update(T entity) {
            var updatedEntity = _context.Set<T>().Find(entity.Id);
            _context.Entry(updatedEntity).CurrentValues.SetValues(entity);
            //_context.Set<T>().Update(entity);
        }

    }
}