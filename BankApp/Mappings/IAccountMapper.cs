using BankApp.Data.Entities;
using BankApp.Models;

namespace BankApp.Mappings {
    public interface IAccountMapper {
        Account Map(AccountCreateModel model);
    }
}