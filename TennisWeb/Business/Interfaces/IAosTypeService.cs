using System.Threading.Tasks;
using Common.ResponseObjects;
using Dtos.AosTypeDtos;

namespace Business.Interfaces {
    public interface IAosTypeService {
        Task<Response<AosTypeListDto>> GetById(long? id);
    }
}