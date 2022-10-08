using System.Collections.Generic;
using System.Threading.Tasks;
using Common.ResponseObjects;
using Dtos.PlayingDatumDtos;

namespace Business.Interfaces {
    public interface IPlayingDatumService {
        Task<Response<List<PlayingDatumListDto>>> GetAll();
        Task<Response<PlayingDatumListDto>> GetById(long id);
        Task<Response<List<PlayingDatumRelatedListDto>>> GetAllRelated();
        Task<IResponse> Remove(long id);
        Task<IResponse<PlayingDatumCreateDto>> Create(PlayingDatumCreateDto dto);
    }
}