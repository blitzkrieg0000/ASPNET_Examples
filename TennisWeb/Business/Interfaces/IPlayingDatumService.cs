using System.Collections.Generic;
using System.Threading.Tasks;
using Common.ResponseObjects;
using Dtos.PlayingDatumDtos;
using Dtos.StreamDtos;

namespace Business.Interfaces {
    public interface IPlayingDatumService {
        Task<Response<List<PlayingDatumRelatedListDto>>> GetAll();
        Task<Response<List<PlayingDatumListDto>>> GetPlayingData();
        Task<IResponse> Remove(int id);
        Task<IResponse<StreamCreateDto>> Create(StreamCreateDto dto);
    }
}