using System.Collections.Generic;
using System.Threading.Tasks;
using Common.ResponseObjects;
using Dtos.SessionDtos;

namespace Business.Interfaces {
    public interface ISessionService {
        Task<Response<List<SessionListDto>>> GetAll();
        Task<IResponse<SessionCreateDto>> Create(SessionCreateDto dto);
        Task<IResponse> Remove(long id);
    }
}