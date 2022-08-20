using System.Collections.Generic;
using System.Threading.Tasks;
using Common.ResponseObjects;
using Dtos.StreamDtos;
using Microsoft.AspNetCore.Http;

namespace Business.Interfaces {
    public interface IStreamService {

        Task<Response<List<StreamListDto>>> GetAll();
        Task<Response<StreamListDto>> GetById(int id);
        Task<IResponse<StreamCreateDto>> Create(IFormFile formFile, StreamCreateDto dto);
        Task<IResponse<StreamListDto>> Update(StreamListDto dto);
        Task<IResponse> Remove(int id);
    }
}