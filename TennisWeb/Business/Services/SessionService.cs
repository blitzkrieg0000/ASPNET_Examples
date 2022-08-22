using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Business.Interfaces;
using Common.ResponseObjects;
using DataAccess.UnitOfWork;
using Dtos.SessionDtos;
using UI.Entities.Concrete;

namespace Business.Services {
    public class SessionService : ISessionService {

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public SessionService(IMapper mapper, IUnitOfWork unitOfWork) {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<List<SessionListDto>>> GetAll() {
            var data = _mapper.Map<List<SessionListDto>>(
                await _unitOfWork.GetRepository<Session>().GetAll()
            );
            return new Response<List<SessionListDto>>(ResponseType.Success, data);
        }

        public async Task<IResponse<SessionCreateDto>> Create(SessionCreateDto dto) {
            await _unitOfWork.GetRepository<Session>().Create(_mapper.Map<Session>(dto));
            await _unitOfWork.SaveChanges();
            return new Response<SessionCreateDto>(ResponseType.Success, "Yeni Session Eklendi.");
        }

        public async Task<IResponse> Remove(long id) {
            var removedEntity = await _unitOfWork.GetRepository<Session>().GetByFilter(x => x.Id == id);
            if (removedEntity != null) {
                _unitOfWork.GetRepository<Session>().Remove(removedEntity);
                await _unitOfWork.SaveChanges();
                return new Response(ResponseType.Success);
            }
            return new Response(ResponseType.NotFound, $"{id} ye ait veri bulunamadı!");
        }

    }
}