using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Common.ResponseObjects;
using Dtos.SessionParameterDtos;
using Entities.Concrete;

namespace Business.Interfaces {
    public interface IProcessParameterService {
        Task<Response<List<SessionParameterListDto>>> GetAll();
        Task<Response<List<SessionParameterListDto>>> GetListByFilter(Expression<Func<SessionParameter, bool>> filter);
        Task<IResponse<SessionParameterCreatetDto>> Create(SessionParameterCreatetDto dto);
        Task<IResponse> Remove(long id);
    }
}