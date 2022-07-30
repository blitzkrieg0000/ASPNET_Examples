using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dtos.WorkDtos;

namespace Business.Interfaces {
    public interface IWorkService {

        Task<List<WorkListDto>> GetAll();



    }
}