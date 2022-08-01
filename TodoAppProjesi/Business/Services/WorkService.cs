using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Business.Interfaces;
using DataAccess.UnitOfWork;
using Dtos.WorkDtos;
using Entities.Concrete;

namespace Business.Services {
    public class WorkService : IWorkService {

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public WorkService(IUnitOfWork unitOfWork, IMapper mapper) {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task Create(WorkCreateDto dto) {
            await _unitOfWork.GetRepository<Work>().Create(_mapper.Map<Work>(dto));
            await _unitOfWork.SaveChanges();
        }


        public async Task<List<WorkListDto>> GetAll() {

            return _mapper.Map<List<WorkListDto>>(
                await _unitOfWork.GetRepository<Work>().GetAll()
            );
        }


        public async Task<WorkListDto> GetById(int id) {
            return _mapper.Map<WorkListDto>(
                await _unitOfWork.GetRepository<Work>().GetByFilter(x => x.Id == id, asNoTracking: false)
            );
        }


        public async Task Remove(int id) {
            _unitOfWork.GetRepository<Work>().Remove(id);
            await _unitOfWork.SaveChanges();
        }


        public async Task Update(WorkUpdateDto dto) {
            _unitOfWork.GetRepository<Work>().Update(_mapper.Map<Work>(dto));
            await _unitOfWork.SaveChanges();
        }


    }
}