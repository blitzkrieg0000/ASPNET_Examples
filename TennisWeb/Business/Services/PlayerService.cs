using System.Threading.Tasks;
using AutoMapper;
using Business.Interfaces;
using Common.ResponseObjects;
using DataAccess.UnitOfWork;
using Dtos.PlayerDtos;
using UI.Entities.Concrete;

namespace Business.Services {
    public class PlayerService : IPlayerService {

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PlayerService(IMapper mapper, IUnitOfWork unitOfWork) {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<PlayerListDto>> GetById(long id) {
            var data = _mapper.Map<PlayerListDto>(
                await _unitOfWork.GetRepository<Player>().GetByFilter(x => x.Id == id, asNoTracking: false)
            );
            return new Response<PlayerListDto>(ResponseType.Success, data);
        }
    }
}