using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Business.Interfaces;
using Common.ResponseObjects;
using DataAccess.UnitOfWork;
using Dtos.CourtDtos;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Business.Services {
    public class CourtService : ICourtService {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CourtService(IMapper mapper, IUnitOfWork unitOfWork) {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<List<CourtListDto>>> GetAll() {
            var data = _mapper.Map<List<CourtListDto>>(
                await _unitOfWork.GetRepository<Court>().GetAll()
            );
            return new Response<List<CourtListDto>>(ResponseType.Success, data);
        }


        public async Task<Response<List<CourtListRelatedDto>>> GetAllRelated() {

            var query = _unitOfWork.GetRepository<Court>().GetQuery();
            var data = await query.Include(x=>x.CourtType)
            .ProjectTo<CourtListRelatedDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
            return new Response<List<CourtListRelatedDto>>(ResponseType.Success, data);
        }


        public async Task<Response<CourtListDto>> GetById(long? id) {
            var data = _mapper.Map<CourtListDto>(
                await _unitOfWork.GetRepository<Court>().GetByFilter(x => x.Id == id, asNoTracking: false)
            );
            return new Response<CourtListDto>(ResponseType.Success, data);
        }

        public async Task<IResponse<CourtCreateDto>> Create(CourtCreateDto dto) {
            await _unitOfWork.GetRepository<Court>().Create(_mapper.Map<Court>(dto));
            await _unitOfWork.SaveChanges();
            return new Response<CourtCreateDto>(ResponseType.Success, "Yeni Court Eklendi.");
        }

    }
}