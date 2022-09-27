using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Business.Interfaces;
using Common.ResponseObjects;
using DataAccess.UnitOfWork;
using Dtos.ProcessDtos;
using Dtos.ProcessResponseDtos;
using Dtos.StreamDtos;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Business.Services {
    public class ProcessService : IProcessService {

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ProcessService(IMapper mapper, IUnitOfWork unitOfWork) {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<List<ProcessListDto>>> GetAll() {
            var data = _mapper.Map<List<ProcessListDto>>(
                await _unitOfWork.GetRepository<Process>().GetAll()
            );
            return new Response<List<ProcessListDto>>(ResponseType.Success, data);
        }

        public async Task<Response<List<ProcessListRelatedDto>>> GetAllRelated(long id) {
            var query = _unitOfWork.GetRepository<Process>().GetQuery();

            var raw = await query
                .Include(x => x.Session)
                .ThenInclude(x => x.SessionParameter)
                .Include(x => x.ProcessParameter)
                .Include(x => x.ProcessResponse)
                .Join(_unitOfWork.GetRepository<Stream>().GetQuery(),
                 src => src.ProcessParameter.StreamId == null ? src.Session.SessionParameter.StreamId :
                  src.ProcessParameter.StreamId, dst => dst.Id,
                 (Process, Stream) => new { Process, Stream })
                 .Where(x => x.Process.SessionId == id)
                .ToListAsync();

            List<ProcessListRelatedDto> data = new();

            foreach (var item in raw) {
                data.Add(new() {
                    Process = _mapper.Map<ProcessListDto>(item.Process),
                    ProcessResponse = _mapper.Map<ProcessResponseListDto>(item.Process.ProcessResponse),
                    Stream = _mapper.Map<StreamListDto>(item.Stream)
                });
            }
            return new Response<List<ProcessListRelatedDto>>(ResponseType.Success, data);
        }


        public async Task<Response<List<ProcessListDto>>> GetListByFilter(Expression<Func<Process, bool>> filter) {
            var raw = await _unitOfWork.GetRepository<Process>().GetListByFilter(filter, asNoTracking: false);

            var data = _mapper.Map<List<ProcessListDto>>(
                raw
            );
            return new Response<List<ProcessListDto>>(ResponseType.Success, data);
        }


        public async Task<IResponse<ProcessCreateDto>> Create(ProcessCreateDto dto) {

            var stream_id_video = await _unitOfWork.GetRepository<Stream>().GetByFilter(x => x.Id == dto.StreamId, asNoTracking: true);
            var data = _mapper.Map<Process>(dto);

            if (stream_id_video != null) {
                if (stream_id_video.IsVideo) {
                    data.IsCompleted = false;
                }
            }

            if (dto.Override == 0) {
                data.ProcessParameter = new ProcessParameter();
            }

            await _unitOfWork.GetRepository<Process>().Create(data);
            await _unitOfWork.SaveChanges();

            return new Response<ProcessCreateDto>(ResponseType.Success, "Yeni Process Eklendi.");
        }


        public async Task<IResponse> Remove(long id) {
            var removedEntity = await _unitOfWork.GetRepository<Process>().GetByFilter(x => x.Id == id);
            if (removedEntity != null) {
                _unitOfWork.GetRepository<Process>().Remove(removedEntity);
                await _unitOfWork.SaveChanges();
                return new Response(ResponseType.Success);
            }
            
            return new Response(ResponseType.NotFound, $"{id} ye ait veri bulunamadı!");
        }


    }
}