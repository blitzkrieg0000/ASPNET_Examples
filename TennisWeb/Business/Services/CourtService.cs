using System.Threading.Tasks;
using AutoMapper;
using Business.Interfaces;
using Common.ResponseObjects;
using DataAccess.UnitOfWork;
using Dtos.CourtDtos;
using UI.Entities.Concrete;

namespace Business.Services {
    public class CourtService : ICourtService {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CourtService(IMapper mapper, IUnitOfWork unitOfWork) {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<CourtListDto>> GetById(long id) {
            var data = _mapper.Map<CourtListDto>(
                await _unitOfWork.GetRepository<Court>().GetByFilter(x => x.Id == id, asNoTracking: false)
            );
            return new Response<CourtListDto>(ResponseType.Success, data);
        }

    }
}