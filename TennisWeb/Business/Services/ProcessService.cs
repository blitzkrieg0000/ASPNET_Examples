using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Business.Interfaces;
using Common.ResponseObjects;
using DataAccess.UnitOfWork;
using Dtos.ProcessDtos;
using Entities.Concrete;

namespace Business.Services {
    public class ProcessService : IProcessService {

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ProcessService(IMapper mapper, IUnitOfWork unitOfWork) {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<List<ProcessListDto>>> GetAll() {
            var data = _mapper.Map<List<ProcessListDto>>(
                await _unitOfWork.GetRepository<Process>().GetAll()
            );
            return new Response<List<ProcessListDto>>(ResponseType.Success, data);
        }

        public async Task<Response<List<ProcessListDto>>> GetListByFilter(Expression<Func<Process, bool>> filter) {
            var raw = await _unitOfWork.GetRepository<Process>().GetListByFilter(filter, asNoTracking: false);
            
            var data = _mapper.Map<List<ProcessListDto>>(
                raw
            );
            return new Response<List<ProcessListDto>>(ResponseType.Success, data);
        }

        public async Task<IResponse<ProcessCreateDto>> Create(ProcessCreateDto dto) {
            await _unitOfWork.GetRepository<Process>().Create(_mapper.Map<Process>(dto));
            await _unitOfWork.SaveChanges();
            return new Response<ProcessCreateDto>(ResponseType.Success, "Yeni Session Eklendi.");
        }

        public async Task<IResponse> Remove(long id) {
            var removedEntity = await _unitOfWork.GetRepository<Process>().GetByFilter(x => x.Id == id);
            if (removedEntity != null) {
                _unitOfWork.GetRepository<Process>().Remove(removedEntity);
                await _unitOfWork.SaveChanges();
                return new Response(ResponseType.Success);
            }
            return new Response(ResponseType.NotFound, $"{id} ye ait veri bulunamadı!");
        }
    }
}