using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Business.Interfaces;
using Common.ResponseObjects;
using DataAccess.UnitOfWork;
using Dtos.ProcessResponseDtos;
using Entities.Concrete;

namespace Business.Services {
    public class ProcessResponseService : IProcessResponseService {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ProcessResponseService(IMapper mapper, IUnitOfWork unitOfWork) {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        
        public async Task<Response<List<ProcessResponseListDto>>> GetAll() {
            var data = _mapper.Map<List<ProcessResponseListDto>>(
                await _unitOfWork.GetRepository<ProcessResponse>().GetAll()
            );

            return new Response<List<ProcessResponseListDto>>(ResponseType.Success, data);
        }





    }
}