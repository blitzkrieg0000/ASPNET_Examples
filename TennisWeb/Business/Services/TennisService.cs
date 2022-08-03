using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Business.Interfaces;
using Common.ResponseObjects;
using DataAccess.UnitOfWork;
using Dtos.TennisDtos;
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

        public async Task<Response<List<PlayingDatumListDto>>> GetAll() {

            var data = _mapper.Map<List<PlayingDatumListDto>>(
                await _unitOfWork.GetRepository<PlayingDatum>().GetAll()
            );

            return new Response<List<PlayingDatumListDto>>(ResponseType.Success, data);
        }

    }
}