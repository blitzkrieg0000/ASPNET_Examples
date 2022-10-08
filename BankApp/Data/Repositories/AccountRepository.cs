using System.Collections.Generic;
using System.Linq;
using BankApp.Data.Contexts;
using BankApp.Data.Entities;
using BankApp.Data.Interfaces;

namespace BankApp.Data.Repositories {
    public class AccountRepository : IAccountRepository {

        private readonly BankContext _context;
        public AccountRepository(BankContext context) {
            _context = context;
        }


        public void Create(Account account) {
            _context.Set<Account>().Add(account);
            _context.SaveChanges();
        }

        public void Remove(Account account) {
            _context.Set<Account>().Remove(account);
            _context.SaveChanges();
        }

        public List<Account> GetAll() {
            return _context.Set<Account>().ToList();
        }


    }
}