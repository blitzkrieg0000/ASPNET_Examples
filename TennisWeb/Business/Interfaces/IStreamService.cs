using System.Collections.Generic;
using System.Threading.Tasks;
using Common.ResponseObjects;
using Dtos.TennisDtos;

namespace Business.Interfaces {
    public interface IStreamService {
        Task<IResponse> Remove(int id);
        Task<Response<List<StreamListDto>>> GetAll();
        Task<Response<StreamListDto>> GetById(int id);
        Task<IResponse<StreamListDto>> Update(StreamListDto dto);
    }
}