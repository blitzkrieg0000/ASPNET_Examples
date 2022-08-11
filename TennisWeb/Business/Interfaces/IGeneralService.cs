using System.Threading.Tasks;
using Common.ResponseObjects;
using Dtos.TennisDtos;

namespace Business.Interfaces {
    public interface IGeneralService {
        Task<Response<GeneralDto>> GetAll();
    }
}