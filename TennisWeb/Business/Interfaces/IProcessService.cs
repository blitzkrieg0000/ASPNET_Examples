using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Common.ResponseObjects;
using Dtos.ProcessDtos;
using Entities.Concrete;

namespace Business.Interfaces {
    public interface IProcessService {
        Task<Response<List<ProcessListDto>>> GetAll();
        Task<IResponse<ProcessCreateDto>> Create(ProcessCreateDto dto);
        Task<Response<List<ProcessListDto>>> GetListByFilter(Expression<Func<Process, bool>> filter);
        Task<IResponse> Remove(long id);
    }
}