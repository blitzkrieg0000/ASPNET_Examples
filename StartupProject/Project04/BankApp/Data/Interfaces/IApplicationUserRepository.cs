using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApp.Data.Entities;

namespace BankApp.Data.Interfaces {

    public interface IApplicationUserRepository {
        List<ApplicationUser> GetAllUser();
        ApplicationUser GetUserById(int id);
        void Create(ApplicationUser user);
        void Remove(ApplicationUser user);
        List<ApplicationUser> GetAll();
    }

}