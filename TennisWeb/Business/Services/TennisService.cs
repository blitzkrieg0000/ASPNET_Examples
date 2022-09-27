
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Business.Interfaces;
using Common.ResponseObjects;
using DataAccess.UnitOfWork;
using Dtos.GRPCData;
using Dtos.ProcessResponseDtos;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IResponse> CalculateTotalScore(long sessionId){
            var query = _unitOfWork.GetRepository<Process>().GetQuery().AsNoTracking();
            var score = (long)await query
                .Where(x => x.SessionId == sessionId)
                .Include(x => x.ProcessResponse)
                .Select(x => x.ProcessResponse.Score)
                .SumAsync();

            var querySessionParameter = _unitOfWork.GetRepository<SessionParameter>().GetQuery().AsNoTracking();
            var data = _mapper.Map<PlayingDatum>(
                await querySessionParameter.Where(x => x.Id == sessionId).SingleOrDefaultAsync()
            );
            data.Score = score;
            data.Id = 0;

            await _unitOfWork.GetRepository<PlayingDatum>().Create(data);
            await _unitOfWork.SaveChanges();

            return new Response(ResponseType.Success);
        }
        

    }
}