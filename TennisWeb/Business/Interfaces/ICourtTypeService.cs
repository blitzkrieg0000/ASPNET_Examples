using System.Threading.Tasks;
using Common.ResponseObjects;
using Dtos.CourtTypeDtos;

namespace Business.Interfaces {
    public interface ICourtTypeService {
        Task<Response<CourtTypeListDto>> GetById(long id);
    }
}