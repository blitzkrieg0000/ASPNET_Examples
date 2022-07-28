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



        public void Create(ApplicationUser user){
            _context.Set<ApplicationUser>().Add(user);
            _context.SaveChanges();
        }

        public void Remove(ApplicationUser user){
            _context.Set<ApplicationUser>().Remove(user);
            _context.SaveChanges();
        }

        public List<ApplicationUser> GetAll(){
            return _context.Set<ApplicationUser>().ToList();
        }
        
    }
}