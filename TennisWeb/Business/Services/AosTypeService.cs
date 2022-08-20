using System.Threading.Tasks;
using AutoMapper;
using Business.Interfaces;
using Common.ResponseObjects;
using DataAccess.UnitOfWork;
using Dtos.AosTypeDtos;
using UI.Entities.Concrete;

namespace Business.Services {
    public class AosTypeService : IAosTypeService {

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public AosTypeService(IMapper mapper, IUnitOfWork unitOfWork) {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<AosTypeListDto>> GetById(long id) {
            var data = _mapper.Map<AosTypeListDto>(
                await _unitOfWork.GetRepository<AosType>().GetByFilter(x => x.Id == id, asNoTracking: false)
            );
            return new Response<AosTypeListDto>(ResponseType.Success, data);
        }

    }
}