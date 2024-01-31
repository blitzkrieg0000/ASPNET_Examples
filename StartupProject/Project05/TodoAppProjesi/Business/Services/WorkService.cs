using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Business.Extensions;
using Business.Interfaces;
using Common.ResponseObjects;
using DataAccess.UnitOfWork;
using Dtos.WorkDtos;
using Entities.Concrete;
using FluentValidation;

namespace Business.Services {
    public class WorkService : IWorkService {
		// Mapping İşlemleri ve Validation İşlemelerinin çağrılması

		private readonly IMapper _mapper;
		private readonly IUnitOfWork _unitOfWork;
		private readonly IValidator<WorkCreateDto> _createDtoValidator;
		private readonly IValidator<WorkUpdateDto> _updateDtoValidator;
		public WorkService(IUnitOfWork unitOfWork, IMapper mapper, IValidator<WorkCreateDto> createDtoValidator = null, IValidator<WorkUpdateDto> updateDtoValidator = null) {
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_createDtoValidator = createDtoValidator;
			_updateDtoValidator = updateDtoValidator;
		}

		public async Task<IResponse<WorkCreateDto>> Create(WorkCreateDto dto) {

			var validationResult = _createDtoValidator.Validate(dto);

			if (validationResult.IsValid) {
				await _unitOfWork.GetRepository<Work>().Create(_mapper.Map<Work>(dto));
				await _unitOfWork.SaveChanges();
				return new Response<WorkCreateDto>(ResponseType.Success, dto);

			} else {
				return new Response<WorkCreateDto>(ResponseType.ValidationError, dto, validationResult.ConvertToCustomValidationError());
			}
		}


		public async Task<Response<List<WorkListDto>>> GetAll() {

			var data = _mapper.Map<List<WorkListDto>>(
				await _unitOfWork.GetRepository<Work>().GetAll()
			);

			return new Response<List<WorkListDto>>(ResponseType.Success, data);
		}


		public async Task<IResponse<IDto>> GetById<IDto>(int id) {

			var data = _mapper.Map<IDto>(
				await _unitOfWork.GetRepository<Work>().GetByFilter(x => x.Id == id, asNoTracking: false)
			);

			if (data == null) {
				return new Response<IDto>(ResponseType.NotFound, $"{id} ye ait veri bulunamadı!");
			}
			return new Response<IDto>(ResponseType.Success, data);
		}


		public async Task<IResponse> Remove(int id) {
			var removedEntity = await _unitOfWork.GetRepository<Work>().GetByFilter(x => x.Id == id);

			if (removedEntity != null) {
				_unitOfWork.GetRepository<Work>().Remove(removedEntity);
				await _unitOfWork.SaveChanges();
				return new Response(ResponseType.Success);
			}
			return new Response(ResponseType.NotFound, $"{id} ye ait veri bulunamadı!");
		}


		public async Task<IResponse<WorkUpdateDto>> Update(WorkUpdateDto dto) {
			var validationResult = _updateDtoValidator.Validate(dto);
			if (validationResult.IsValid) {
				var updatedEntity = await _unitOfWork.GetRepository<Work>().Find(dto.Id);
				if (updatedEntity != null) {
					_unitOfWork.GetRepository<Work>().Update(_mapper.Map<Work>(dto), updatedEntity);
					await _unitOfWork.SaveChanges();
					return new Response<WorkUpdateDto>(ResponseType.Success, dto);
				}
				return new Response<WorkUpdateDto>(ResponseType.NotFound, $"{dto.Id} ye ait veri bulunamadı!");

			} else {
				return new Response<WorkUpdateDto>(ResponseType.ValidationError, dto, validationResult.ConvertToCustomValidationError());
			}
		}


	}
}