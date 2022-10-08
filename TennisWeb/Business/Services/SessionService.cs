using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Business.Extensions;
using Business.Interfaces;
using Common.ResponseObjects;
using DataAccess.UnitOfWork;
using Dtos.SessionDtos;
using Entities.Concrete;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Business.Services {
    public class SessionService : ISessionService {

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<SessionCreateDto> _sessionCreateDtoValidator;
        public SessionService(IMapper mapper, IUnitOfWork unitOfWork, IValidator<SessionCreateDto> sessionCreateDtoValidator) {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _sessionCreateDtoValidator = sessionCreateDtoValidator;
        }

        public async Task<Response<List<SessionListDto>>> GetAll() {
            var data = _mapper.Map<List<SessionListDto>>(
                await _unitOfWork.GetRepository<Session>().GetAll()
            );
            return new Response<List<SessionListDto>>(ResponseType.Success, data);
        }

        public async Task<IResponse<SessionCreateDto>> Create(SessionCreateDto dto) {
            var data = _mapper.Map<Session>(dto);
            var validationResult = _sessionCreateDtoValidator.Validate(dto);

            if (validationResult.IsValid) {
                await _unitOfWork.GetRepository<Session>().Create(data);
                await _unitOfWork.SaveChanges();
            } else {
                return new Response<SessionCreateDto>(ResponseType.ValidationError, dto, validationResult.ConvertToCustomValidationError());
            }
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