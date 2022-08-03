using System.Collections.Generic;
using System.Threading.Tasks;
using Common.ResponseObjects;
using Dtos.TennisDtos;

namespace Business.Interfaces {
    public interface ITennisService {

        Task<Response<List<PlayingDatumListDto>>> GetAll();
        
    }
}