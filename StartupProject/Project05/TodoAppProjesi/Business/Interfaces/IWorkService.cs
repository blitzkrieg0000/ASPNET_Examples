using System.Collections.Generic;
using System.Threading.Tasks;
using Common.ResponseObjects;
using Dtos.WorkDtos;

namespace Business.Interfaces {
    public interface IWorkService {

        Task<IResponse<WorkCreateDto>> Create(WorkCreateDto dto);

        Task<Response<List<WorkListDto>>> GetAll();
        
        Task<IResponse<IDto>> GetById<IDto>(int id);

        Task<IResponse> Remove(int id);

        Task<IResponse<WorkUpdateDto>> Update(WorkUpdateDto dto);

    }
}