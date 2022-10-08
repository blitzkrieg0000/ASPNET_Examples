using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Common.ResponseObjects;
using Dtos.Interface;
using Entities.Concrete;

namespace Business.Interfaces {
    public interface IGenericService {
        Task<Response<List<DtoT>>> GetAll<DtoT, RepositoryT>() where DtoT : IDto where RepositoryT : BaseEntity;
        Task<Response<List<DtoT>>> GetListByFilter<DtoT, RepositoryT>(Expression<Func<RepositoryT, bool>> filter) where DtoT : IDto where RepositoryT : BaseEntity;
    }
}