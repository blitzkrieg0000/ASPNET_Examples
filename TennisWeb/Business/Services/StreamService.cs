using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Business.Interfaces;
using Common.ResponseObjects;
using DataAccess.UnitOfWork;
using Dtos.TennisDtos;
using UI.Entities.Concrete;

namespace Business.Services {
    public class StreamService : IStreamService {
        // Mapping İşlemleri ve Validation İşlemelerinin çağrılması

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public StreamService(IUnitOfWork unitOfWork, IMapper mapper) {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<List<StreamListDto>>> GetAll() {
            var data = _mapper.Map<List<StreamListDto>>(
                await _unitOfWork.GetRepository<Stream>().GetAll()
            );
            return new Response<List<StreamListDto>>(ResponseType.Success, data);
        }

        public async Task<Response<StreamListDto>> GetById(int id) {
            var data = _mapper.Map<StreamListDto>(
                await _unitOfWork.GetRepository<Stream>().GetByFilter(x => x.Id == id, asNoTracking: false)
            );
            return new Response<StreamListDto>(ResponseType.Success, data);
        }

        public async Task<IResponse> Remove(int id) {
            var removedEntity = await _unitOfWork.GetRepository<Stream>().GetByFilter(x => x.Id == id);

            if (removedEntity != null) {
                _unitOfWork.GetRepository<Stream>().Remove(removedEntity);
                await _unitOfWork.SaveChanges();
                return new Response(ResponseType.Success);
            }
            return new Response(ResponseType.NotFound, $"{id} ye ait veri bulunamadı!");
        }

        public async Task<IResponse<StreamListDto>> Update(StreamListDto dto) {
            var updatedEntity = await _unitOfWork.GetRepository<Stream>().Find(dto.Id);
            _unitOfWork.GetRepository<Stream>().Update(_mapper.Map<Stream>(dto), updatedEntity);
            
            await _unitOfWork.SaveChanges();

            return new Response<StreamListDto>(ResponseType.Success, dto);
        }



    }
}