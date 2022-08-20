using System.Collections.Generic;
using System.Threading.Tasks;
using Common.ResponseObjects;
using Dtos.Interface;
using Entities.Concrete;

namespace Business.Interfaces {
    public interface IGenericService {
        Task<Response<List<DtoT>>> GetAll<DtoT, RepositoryT>() where DtoT : IDto where RepositoryT : BaseEntity;
    }
}