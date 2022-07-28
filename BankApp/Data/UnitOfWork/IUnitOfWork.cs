using BankApp.Data.Interfaces;

namespace BankApp.Data.UnitOfWork {
    public interface IUnitOfWork {

        IRepository<T> GetRepository<T>() where T : class, new();
        
        void SaveChanges();
    }
}