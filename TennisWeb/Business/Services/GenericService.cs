using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Business.Interfaces;
using Common.ResponseObjects;
using DataAccess.UnitOfWork;
using Dtos.Interface;
using Entities.Concrete;

namespace Business.Services {
    public class GenericService : IGenericService {


        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GenericService(IMapper mapper, IUnitOfWork unitOfWork) {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<List<DtoT>>> GetAll<DtoT, RepositoryT>()
        where DtoT : IDto
        where RepositoryT : BaseEntity {

            var data = _mapper.Map<List<DtoT>>(
                await _unitOfWork.GetRepository<RepositoryT>()
                .GetAll()
            );
            return new Response<List<DtoT>>(ResponseType.Success, data);
        }

    }
}