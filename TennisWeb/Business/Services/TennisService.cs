using System;
using System.Threading.Tasks;
using AutoMapper;
using Business.Interfaces;
using Common.ResponseObjects;
using DataAccess.UnitOfWork;
using Dtos.GRPCData;
using Dtos.ProcessResponseDtos;
using Entities.Concrete;

namespace Business.Services {
    public class TennisService : ITennisService {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public TennisService(IMapper mapper, IUnitOfWork unitOfWork) {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IResponse<GenerateProcessModel>> Create(GenerateProcessModel dto) {

            var newTable = _mapper.Map<SessionParameter>(dto);
            await _unitOfWork.GetRepository<SessionParameter>().Create(newTable);

            var newProcessResponse = _mapper.Map<ProcessResponse>(new ProcessResponseCreateDto());
            await _unitOfWork.GetRepository<ProcessResponse>().Create(newProcessResponse);

            var newProcess = _mapper.Map<Process>(dto);
            await _unitOfWork.GetRepository<Process>().Create(newProcess);
            await _unitOfWork.SaveChanges();

            return new Response<GenerateProcessModel>(ResponseType.Success, "Yeni Process Eklendi.");
        }


    }
}