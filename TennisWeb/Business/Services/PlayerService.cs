using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Business.Interfaces;
using Common.ResponseObjects;
using DataAccess.UnitOfWork;
using Dtos.PlayerDtos;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Business.Services {
    public class PlayerService : IPlayerService {

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PlayerService(IMapper mapper, IUnitOfWork unitOfWork) {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<List<PlayerListDto>>> GetAll() {
            var data = _mapper.Map<List<PlayerListDto>>(
                await _unitOfWork.GetRepository<Player>().GetAll()
            );

            return new Response<List<PlayerListDto>>(ResponseType.Success, data);
        }

        public async Task<Response<List<PlayerListRelatedDto>>> GetAllRelated() {
            var query = _unitOfWork.GetRepository<Player>().GetQuery();
            var data = await query.Include(x => x.Gender)
            .ProjectTo<PlayerListRelatedDto>(_mapper.ConfigurationProvider).ToListAsync();
            return new Response<List<PlayerListRelatedDto>>(ResponseType.Success, data);
        }

        public async Task<Response<PlayerListDto>> GetById(long? id) {
            var data = _mapper.Map<PlayerListDto>(
                await _unitOfWork.GetRepository<Player>().GetByFilter(x => x.Id == id, asNoTracking: false)
            );

            return new Response<PlayerListDto>(ResponseType.Success, data);
        }

        public async Task<IResponse<PlayerCreateDto>> Create(PlayerCreateDto dto) {
            await _unitOfWork.GetRepository<Player>().Create(_mapper.Map<Player>(dto));
            await _unitOfWork.SaveChanges();

            return new Response<PlayerCreateDto>(ResponseType.Success, "Yeni Oyuncu Eklendi.");
        }

        public async Task<IResponse> Remove(long? id) {
            var removedEntity = await _unitOfWork.GetRepository<Player>().GetByFilter(x => x.Id == id);
            if (removedEntity != null) {
                _unitOfWork.GetRepository<Player>().Remove(removedEntity);
                await _unitOfWork.SaveChanges();

                return new Response(ResponseType.Success);
            }
            return new Response(ResponseType.NotFound, $"{id} ye ait veri bulunamadı!");
        }

    }
}