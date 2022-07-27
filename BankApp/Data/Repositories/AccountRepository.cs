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
            _context.Accounts.Add(account);
            _context.SaveChanges();
        }

    }
}