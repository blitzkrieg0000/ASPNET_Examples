using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Common.ResponseObjects;
using Dtos.ProcessParameterDtos;
using UI.Entities.Concrete;

namespace Business.Interfaces {
    public interface IProcessParameterService {
        Task<Response<List<ProcessParameterListDto>>> GetAll();
        Task<Response<List<ProcessParameterListDto>>> GetListByFilter(Expression<Func<ProcessParameter, bool>> filter);
        Task<IResponse<ProcessParameterCreateDto>> Create(ProcessParameterCreateDto dto);
        Task<IResponse> Remove(long id);
    }
}