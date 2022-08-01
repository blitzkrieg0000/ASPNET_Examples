using System.Collections.Generic;
using System.Threading.Tasks;
using Dtos.WorkDtos;

namespace Business.Interfaces {
    public interface IWorkService {

        Task<List<WorkListDto>> GetAll();

        Task Create(WorkCreateDto dto);

        Task<IDto> GetById<IDto>(int id);

        Task Remove(int id);

        Task Update(WorkUpdateDto dto);
    }
}