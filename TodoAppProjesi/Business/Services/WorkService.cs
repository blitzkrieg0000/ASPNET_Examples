using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Business.Interfaces;
using Business.ValidationRules;
using DataAccess.UnitOfWork;
using Dtos.WorkDtos;
using Entities.Concrete;
using FluentValidation;

namespace Business.Services {
    public class WorkService : IWorkService {

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

        public async Task Create(WorkCreateDto dto) {

            var validator = _createDtoValidator.Validate(dto);
            if (validator.IsValid) {
                await _unitOfWork.GetRepository<Work>().Create(_mapper.Map<Work>(dto));
                await _unitOfWork.SaveChanges();
            }

        }

        public async Task<List<WorkListDto>> GetAll() {

            return _mapper.Map<List<WorkListDto>>(
                await _unitOfWork.GetRepository<Work>().GetAll()
            );
        }

        public async Task<IDto> GetById<IDto>(int id) {
            return _mapper.Map<IDto>(
                await _unitOfWork.GetRepository<Work>().GetByFilter(x => x.Id == id, asNoTracking: false)
            );
        }

        public async Task Remove(int id) {
            _unitOfWork.GetRepository<Work>().Remove(id);
            await _unitOfWork.SaveChanges();
        }

        public async Task Update(WorkUpdateDto dto) {
            var result = _updateDtoValidator.Validate(dto);
            if (result.IsValid) {
                _unitOfWork.GetRepository<Work>().Update(_mapper.Map<Work>(dto));
                await _unitOfWork.SaveChanges();
            }

        }


    }
}