using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Business.Interfaces;
using Common.ResponseObjects;
using DataAccess.UnitOfWork;
using Dtos.ProcessParameterDtos;
using UI.Entities.Concrete;

namespace Business.Services {
    public class ProcessParameterService : IProcessParameterService {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ProcessParameterService(IMapper mapper, IUnitOfWork unitOfWork) {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<List<ProcessParameterListDto>>> GetAll() {
            var data = _mapper.Map<List<ProcessParameterListDto>>(
                await _unitOfWork.GetRepository<ProcessParameter>().GetAll()
            );
            return new Response<List<ProcessParameterListDto>>(ResponseType.Success, data);
        }

        public async Task<Response<List<ProcessParameterListDto>>> GetListByFilter(Expression<Func<ProcessParameter, bool>> filter) {
            var raw = await _unitOfWork.GetRepository<ProcessParameter>().GetListByFilter(filter, asNoTracking: false);

            var data = _mapper.Map<List<ProcessParameterListDto>>(
                raw
            );
            return new Response<List<ProcessParameterListDto>>(ResponseType.Success, data);
        }

        public async Task<IResponse<ProcessParameterCreateDto>> Create(ProcessParameterCreateDto dto) {
            await _unitOfWork.GetRepository<ProcessParameter>().Create(_mapper.Map<ProcessParameter>(dto));
            await _unitOfWork.SaveChanges();
            return new Response<ProcessParameterCreateDto>(ResponseType.Success, "Yeni ProcessParameter Eklendi.");
        }

        public async Task<IResponse> Remove(long id) {
            var removedEntity = await _unitOfWork.GetRepository<ProcessParameter>().GetByFilter(x => x.Id == id);
            if (removedEntity != null) {
                _unitOfWork.GetRepository<ProcessParameter>().Remove(removedEntity);
                await _unitOfWork.SaveChanges();
                return new Response(ResponseType.Success);
            }
            return new Response(ResponseType.NotFound, $"{id} ye ait veri bulunamadı!");
        }

    }
}