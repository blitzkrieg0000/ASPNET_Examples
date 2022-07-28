using BankApp.Data.Contexts;
using BankApp.Data.Interfaces;
using BankApp.Data.Repositories;

namespace BankApp.Data.UnitOfWork {
    public class UnitOfWork : IUnitOfWork {
        private readonly BankContext _context;

        public UnitOfWork(BankContext context) {
            _context = context;
        }

        public IRepository<T> GetRepository<T>() where T : class, new() {
            return new Repository<T>(_context);
        }

        public void SaveChanges() {
            _context.SaveChanges();
        }
    }
}