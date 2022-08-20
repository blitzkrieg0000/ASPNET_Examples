using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.ResponseObjects;
using Dtos.PlayerDtos;

namespace Business.Interfaces {
    public interface IPlayerService {
        Task<Response<PlayerListDto>> GetById(long id);
    }
}