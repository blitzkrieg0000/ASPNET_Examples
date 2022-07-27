using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApp.Data.Entities;
using BankApp.Models;

namespace BankApp.Mappings {
    public class AccountMapper : IAccountMapper{

        public Account Map(AccountCreateModel model) {

            return new Account {
                AccountNumber = model.AccountNumber,
                ApplicationUserId = model.ApplicationUserId,
                Balance = model.Balance
            };
        }


    }
}