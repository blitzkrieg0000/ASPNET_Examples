using BankApp.Data.Entities;

namespace BankApp.Data.Interfaces {
    public interface IAccountRepository {
        public void Create(Account user);
    }
}