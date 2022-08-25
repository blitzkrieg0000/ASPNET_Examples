using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Business.Interfaces;
using Common.ResponseObjects;
using DataAccess.UnitOfWork;
using Dtos.SessionParameterDtos;
using Entities.Concrete;

namespace Business.Services {
    public class ProcessParameterService : IProcessParameterService {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ProcessParameterService(IMapper mapper, IUnitOfWork unitOfWork) {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<List<SessionParameterListDto>>> GetAll() {
            var data = _mapper.Map<List<SessionParameterListDto>>(
                await _unitOfWork.GetRepository<SessionParameter>().GetAll()
            );
            return new Response<List<SessionParameterListDto>>(ResponseType.Success, data);
        }

        public async Task<Response<List<SessionParameterListDto>>> GetListByFilter(Expression<Func<SessionParameter, bool>> filter) {
            var raw = await _unitOfWork.GetRepository<SessionParameter>().GetListByFilter(filter, asNoTracking: false);

            var data = _mapper.Map<List<SessionParameterListDto>>(
                raw
            );
            return new Response<List<SessionParameterListDto>>(ResponseType.Success, data);
        }

        public async Task<IResponse<SessionParameterCreatetDto>> Create(SessionParameterCreatetDto dto) {
            await _unitOfWork.GetRepository<SessionParameter>().Create(_mapper.Map<SessionParameter>(dto));
            await _unitOfWork.SaveChanges();
            return new Response<SessionParameterCreatetDto>(ResponseType.Success, "Yeni SessionParameter Eklendi.");
        }

        public async Task<IResponse> Remove(long id) {
            var removedEntity = await _unitOfWork.GetRepository<SessionParameter>().GetByFilter(x => x.Id == id);
            if (removedEntity != null) {
                _unitOfWork.GetRepository<SessionParameter>().Remove(removedEntity);
                await _unitOfWork.SaveChanges();
                return new Response(ResponseType.Success);
            }
            return new Response(ResponseType.NotFound, $"{id} ye ait veri bulunamadı!");
        }

    }
}