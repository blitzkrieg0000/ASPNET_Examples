using System.Collections.Generic;
using System.Threading.Tasks;
using Common.ResponseObjects;
using Dtos.PlayingDatumDtos;
using Dtos.StreamDtos;

namespace Business.Interfaces {
    public interface IPlayingDatumService {
        Task<Response<List<PlayingDatumListDto>>> GetAll();
        Task<Response<List<PlayingDatumRelatedListDto>>> GetAllRelated();
        Task<IResponse> Remove(int id);
    }
}