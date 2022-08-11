using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Business.Interfaces;
using Common.ResponseObjects;
using DataAccess.UnitOfWork;
using Dtos.TennisDtos;
using UI.Entities.Concrete;

namespace Business.Services {
    public class GeneralService : IGeneralService {
        // Mapping İşlemleri ve Validation İşlemelerinin çağrılması

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GeneralService(IUnitOfWork unitOfWork, IMapper mapper) {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<GeneralDto>> GetAll() {

            var AOSTypeData = _mapper.Map<List<AOSTypeListDto>>(
                await _unitOfWork.GetRepository<Aostype>().GetAll()
            );

            var StreamData = _mapper.Map<List<StreamListDto>>(
                await _unitOfWork.GetRepository<Stream>().GetAll()
            );

            var PlayerData = _mapper.Map<List<PlayerListDto>>(
                await _unitOfWork.GetRepository<Player>().GetAll()
            );

            var CourtData = _mapper.Map<List<CourtListDto>>(
                await _unitOfWork.GetRepository<Court>().GetAll()
            );

            GeneralDto GeneralDto = new(){
                CourtList = CourtData,
                StreamList = StreamData,
                PlayerList = PlayerData,
                AOSTypeList = AOSTypeData
            };

            return new Response<GeneralDto>(ResponseType.Success, GeneralDto);
        }


    }
}