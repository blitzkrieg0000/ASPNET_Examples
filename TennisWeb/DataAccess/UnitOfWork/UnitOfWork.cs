using System.Threading.Tasks;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using Entities.Concrete;
using UI.Entities.Concrete;

namespace DataAccess.UnitOfWork {
    public class UnitOfWork : IUnitOfWork {
        //Tek bir context üzerinden Repositorylerin kullanılması sağlanıyor.

        private readonly TennisContext _context;
        public UnitOfWork(TennisContext context) {
            _context = context;
        }

        public IRepository<T> GetRepository<T>() where T : BaseEntity {
            return new Repository<T>(_context);
        }

        public async Task SaveChanges() {
            await _context.SaveChangesAsync();
        }

    }
}