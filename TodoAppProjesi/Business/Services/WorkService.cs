using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Interfaces;
using DataAccess.UnitOfWork;
using Dtos.WorkDtos;
using Entities.Concrete;

namespace Business.Services {
    public class WorkService : IWorkService {

        private readonly IUnitOfWork _unitOfWork;
        public WorkService(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }

        public async Task Create(WorkCreateDto dto) {
            await _unitOfWork.GetRepository<Work>().Create(new() {
                Definition = dto.Definition,
                IsCompleted = dto.IsCompleted
            });
            await _unitOfWork.SaveChanges();
        }

        public async Task<List<WorkListDto>> GetAll() {
            var list = await _unitOfWork.GetRepository<Work>().GetAll();

            var workList = new List<WorkListDto>();

            if (list != null && list.Count > 0) {
                foreach (var work in list) {
                    workList.Add(new() {
                        Definition = work.Definition,
                        Id = work.Id,
                        IsCompleted = work.IsCompleted
                    });
                }
            }
            return workList;
        }

        public async Task<WorkListDto> GetById(object id) {
            var work = await _unitOfWork.GetRepository<Work>().GetById(id);
            return new() {
                Definition = work.Definition,
                IsCompleted = work.IsCompleted
            };

        }

        public async Task Remove(object id) {
            var deletedWork = await _unitOfWork.GetRepository<Work>().GetById(id);
            _unitOfWork.GetRepository<Work>().Remove(deletedWork);
            await _unitOfWork.SaveChanges();
        }

        public async Task Update(WorkUpdateDto dto) {
            _unitOfWork.GetRepository<Work>().Update(new() {
                Definition = dto.Definition,
                Id = dto.Id,
                IsCompleted = dto.IsCompleted
            });

            await _unitOfWork.SaveChanges();
        }
    }
}