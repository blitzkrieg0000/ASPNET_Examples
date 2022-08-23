using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Business.Interfaces;
using Common.ResponseObjects;
using DataAccess.UnitOfWork;
using Dtos.CourtDtos;
using Entities.Concrete;

namespace Business.Services {
    public class CourtService : ICourtService {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CourtService(IMapper mapper, IUnitOfWork unitOfWork) {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<List<CourtListDto>>> GetAll() {
            var data = _mapper.Map<List<CourtListDto>>(
                await _unitOfWork.GetRepository<Court>().GetAll()
            );
            return new Response<List<CourtListDto>>(ResponseType.Success, data);
        }

        public async Task<Response<CourtListDto>> GetById(long id) {
            var data = _mapper.Map<CourtListDto>(
                await _unitOfWork.GetRepository<Court>().GetByFilter(x => x.Id == id, asNoTracking: false)
            );
            return new Response<CourtListDto>(ResponseType.Success, data);
        }

        public async Task<IResponse<CourtCreateDto>> Create(CourtCreateDto dto) {
            await _unitOfWork.GetRepository<Court>().Create(_mapper.Map<Court>(dto));
            await _unitOfWork.SaveChanges();
            return new Response<CourtCreateDto>(ResponseType.Success, "Yeni Court Eklendi.");
        }

    }
}