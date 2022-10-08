using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Business.Interfaces;
using Common.ResponseObjects;
using DataAccess.UnitOfWork;
using Dtos.PlayingDatumDtos;

using Microsoft.EntityFrameworkCore;
using Entities.Concrete;
using System.Linq;
using AutoMapper.QueryableExtensions;

namespace Business.Services {
    public class PlayingDatumService : IPlayingDatumService {
        // Mapping İşlemleri ve Validation İşlemelerinin çağrılması

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PlayingDatumService(IUnitOfWork unitOfWork, IMapper mapper) {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<Response<List<PlayingDatumListDto>>> GetAll() {
            var data = _mapper.Map<List<PlayingDatumListDto>>(
                await _unitOfWork.GetRepository<PlayingDatum>().GetAll()
            );
            return new Response<List<PlayingDatumListDto>>(ResponseType.Success, data);
        }


        public async Task<Response<PlayingDatumListDto>> GetById(long id) {
            var data = _mapper.Map<PlayingDatumListDto>(
                await _unitOfWork.GetRepository<PlayingDatum>().GetByFilter(x => x.Id == id, asNoTracking: false)
            );
            return new Response<PlayingDatumListDto>(ResponseType.Success, data);
        }


        public async Task<Response<List<PlayingDatumRelatedListDto>>> GetAllRelated() {
            var query = _unitOfWork.GetRepository<PlayingDatum>().GetQuery();
            var data = await query
            .Include(x => x.Player)
            .Include(x => x.AosType)
            .Include(x => x.Court)
            .Include(x => x.Stream).ProjectTo<PlayingDatumRelatedListDto>(_mapper.ConfigurationProvider)
            .ToListAsync();

            return new Response<List<PlayingDatumRelatedListDto>>(ResponseType.Success, data);
        }


        public async Task<IResponse> Remove(long id) {
            var removedEntity = await _unitOfWork.GetRepository<PlayingDatum>().GetByFilter(x => x.Id == id);

            if (removedEntity != null) {
                _unitOfWork.GetRepository<PlayingDatum>().Remove(removedEntity);
                await _unitOfWork.SaveChanges();
                return new Response(ResponseType.Success);
            }

            return new Response(ResponseType.NotFound, $"{id} ye ait veri bulunamadı!");
        }


        public async Task<IResponse<PlayingDatumCreateDto>> Create(PlayingDatumCreateDto dto) {
            
            await _unitOfWork.GetRepository<PlayingDatum>().Create(_mapper.Map<PlayingDatum>(dto));
            await _unitOfWork.SaveChanges();

            return new Response<PlayingDatumCreateDto>(ResponseType.Success, dto, "Yeni Oynanış Sonucu");
        }


    }
}