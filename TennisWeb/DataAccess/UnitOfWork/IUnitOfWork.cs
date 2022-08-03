using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using Entities.Concrete;

namespace DataAccess.UnitOfWork {
    public interface IUnitOfWork {
        IRepository<T> GetRepository<T>() where T: BaseEntity;
        Task SaveChanges();
    }
}