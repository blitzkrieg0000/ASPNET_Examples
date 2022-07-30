using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Contexts;
using DataAccess.Interfaces;
using DataAccess.Repositories;

namespace DataAccess.UnitOfWork {
    public class UnitOfWork : IUnitOfWork {
        private readonly TodoContext _context;

        public UnitOfWork(TodoContext context) {
            _context = context;
        }

        public IRepository<T> GetRepository<T>() where T : class, new() {
            return new Repository<T>(_context);
        }

        public async Task SaveChanges() {
            await _context.SaveChangesAsync();
        }
    }
}