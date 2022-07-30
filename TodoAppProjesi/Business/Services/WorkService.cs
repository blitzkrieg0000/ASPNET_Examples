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

    }
}