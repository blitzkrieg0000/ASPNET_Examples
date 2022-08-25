using System.Collections.Generic;
using System.Threading.Tasks;
using Common.ResponseObjects;
using Dtos.CourtDtos;

namespace Business.Interfaces {
    public interface ICourtService {
        Task<Response<CourtListDto>> GetById(long? id);
        Task<Response<List<CourtListDto>>> GetAll();
        Task<Response<List<CourtListRelatedDto>>> GetAllRelated();
        Task<IResponse<CourtCreateDto>> Create(CourtCreateDto dto);
    }
}