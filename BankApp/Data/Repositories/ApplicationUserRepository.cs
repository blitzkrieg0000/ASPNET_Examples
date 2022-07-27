using System.Collections.Generic;
using System.Linq;
using BankApp.Data.Contexts;
using BankApp.Data.Entities;
using BankApp.Data.Interfaces;

namespace BankApp.Data.Repositories {
    //Repositoryler bize Entity modeli döndürür fakat biz Viewlerde kendi oluşturduğumuz Model lere MAP ler ve öyle kullanıcıya sunarız.
    public class ApplicationUserRepository : IApplicationUserRepository {

        private readonly BankContext _context;
        public ApplicationUserRepository(BankContext context) {
            _context = context;
        }

        public List<ApplicationUser> GetAllUser() {
            return _context.ApplicationUsers.ToList();
        }
        
        public ApplicationUser GetUserById(int id) {
            return _context.ApplicationUsers.SingleOrDefault(x => x.Id == id);
        }

    }
}