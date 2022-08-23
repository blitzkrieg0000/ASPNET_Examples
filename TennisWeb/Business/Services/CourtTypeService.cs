using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Business.Interfaces;
using Common.ResponseObjects;
using DataAccess.UnitOfWork;
using Dtos.CourtTypeDtos;
using Entities.Concrete;

namespace Business.Services {
    public class CourtTypeService : ICourtTypeService {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CourtTypeService(IMapper mapper, IUnitOfWork unitOfWork) {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<CourtTypeListDto>> GetById(long id) {
            var data = _mapper.Map<CourtTypeListDto>(
                await _unitOfWork.GetRepository<CourtType>().GetByFilter(x => x.Id == id, asNoTracking: false)
            );
            return new Response<CourtTypeListDto>(ResponseType.Success, data);
        }

    }
}