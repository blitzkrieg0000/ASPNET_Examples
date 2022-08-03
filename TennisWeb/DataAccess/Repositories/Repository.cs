using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using UI.Entities.Concrete;

namespace DataAccess.Repositories {
    public class Repository<T> : IRepository<T> where T : BaseEntity {
        // Sadece Database İşlemleri Yapılıyor

        private readonly TenisContext _context;
        public Repository(TenisContext context) {
            _context = context;
        }

        public async Task<List<T>> GetAll() {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

    }
}