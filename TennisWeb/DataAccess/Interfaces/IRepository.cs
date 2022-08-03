using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Entities.Concrete;

namespace DataAccess.Interfaces {
    public interface IRepository<T> where T : BaseEntity {

        Task<List<T>> GetAll();
        
    }
}