using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Business.Interfaces;
using Common.ResponseObjects;
using DataAccess.UnitOfWork;
using Dtos.TennisDtos;
using Microsoft.EntityFrameworkCore;
using UI.Entities.Concrete;

namespace Business.Services {
    public class TennisService : ITennisService {
        // Mapping İşlemleri ve Validation İşlemelerinin çağrılması

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public TennisService(IUnitOfWork unitOfWork, IMapper mapper) {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<Response<List<PlayingDatumRelatedListDto>>> GetAll() {

            var data = _mapper.Map<List<PlayingDatumRelatedListDto>>(

                await _unitOfWork.GetRepository<PlayingDatum>().GetAll()

            );

            return new Response<List<PlayingDatumRelatedListDto>>(ResponseType.Success, data);
        }


        public async Task<Response<List<PlayingDatumListDto>>> GetPlayingData() {
            var query = _unitOfWork.GetRepository<PlayingDatum>().GetQuery();

            //TODO DO MAP
            var raw = await query
            .Include(x => x.Player)
            .Include(x => x.AosType)
            .Include(x => x.Court)
            .Include(x => x.Stream)
            .ToListAsync();

            var data = new List<PlayingDatumListDto>();

            foreach (var item in raw) {
                data.Add(new() {
                    Id = item.Id,
                    Score = item.Score,
                    PlayerName = item.Player.Name,
                    AosTypeName = item.AosType.Name,
                    CourtName = item.Court.Name,
                    IsDeleted = item.IsDeleted,
                    SaveDate = item.SaveDate,
                    BallFallArray = item.BallFallArray,
                    BallPositionArea = item.BallPositionArea,
                });
            }

            return new Response<List<PlayingDatumListDto>>(ResponseType.Success, data);
        }


        public async Task<IResponse> Remove(int id) {
            var removedEntity = await _unitOfWork.GetRepository<PlayingDatum>().GetByFilter(x => x.Id == id);

            if (removedEntity != null) {
                _unitOfWork.GetRepository<PlayingDatum>().Remove(removedEntity);
                await _unitOfWork.SaveChanges();
                return new Response(ResponseType.Success);
            }

            return new Response(ResponseType.NotFound, $"{id} ye ait veri bulunamadı!");
        }


        public async Task<IResponse<StreamCreateDto>> Create(StreamCreateDto dto) {
            await _unitOfWork.GetRepository<Stream>().Create(_mapper.Map<Stream>(dto));
            await _unitOfWork.SaveChanges();
            return new Response<StreamCreateDto>(ResponseType.Success, dto);

        }
    }
}