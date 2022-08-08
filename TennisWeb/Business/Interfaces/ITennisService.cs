using System.Collections.Generic;
using System.Threading.Tasks;
using Common.ResponseObjects;
using Dtos.TennisDtos;

namespace Business.Interfaces {
    public interface ITennisService {
        Task<Response<List<PlayingDatumRelatedListDto>>> GetAll();
        Task<Response<List<PlayingDatumListDto>>> GetPlayingData();
        Task<Response<List<StreamListDto>>> GetStream();
        Task<IResponse> Remove(int id);
        Task<IResponse<StreamCreateDto>> Create(StreamCreateDto dto);
    }
}