using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Business.Interfaces;
using Common.ResponseObjects;
using DataAccess.UnitOfWork;
using Dtos.SessionDtos;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

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
            //TODO Mapping i gözden geçir
            var data = _mapper.Map<Session>(dto);
            await _unitOfWork.GetRepository<Session>().Create(data);
            await _unitOfWork.SaveChanges();
            return new Response<SessionCreateDto>(ResponseType.Success, "Yeni Session Eklendi.");
        }

        public async Task<IResponse> Remove(long id) {
            var query = _unitOfWork.GetRepository<Session>().GetQuery();

            //TODO Repository.cs de CASCADE DELETE METHODU YAP
            var removedEntity = await query.Include(x => x.Processes).SingleOrDefaultAsync(x => x.Id == id);

            if (removedEntity != null) {
                _unitOfWork.GetRepository<Session>().Remove(removedEntity);
                await _unitOfWork.SaveChanges();
                return new Response(ResponseType.Success);
            }
            return new Response(ResponseType.NotFound, $"{id} ye ait veri bulunamadı!");
        }

    }
}