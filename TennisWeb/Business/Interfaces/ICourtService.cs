using System.Collections.Generic;
using System.Threading.Tasks;
using Common.ResponseObjects;
using Dtos.CourtDtos;

namespace Business.Interfaces {
    public interface ICourtService {
        Task<IResponse<CourtListDto>> GetById(long? id);
        Task<IResponse<List<CourtListDto>>> GetAll();
        Task<IResponse<List<CourtListRelatedDto>>> GetAllRelated();
        Task<IResponse<CourtCreateDto>> Create(CourtCreateDto dto);
        Task<IResponse> Remove(long? id);
    }
}