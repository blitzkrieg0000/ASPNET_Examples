using AutoMapper;
using Dtos.AosTypeDtos;
using Dtos.CourtDtos;
using Dtos.CourtTypeDtos;
using Dtos.GRPCData;
using Dtos.PlayerDtos;
using Dtos.PlayingDatumDtos;
using Dtos.ProcessDtos;
using Dtos.ProcessParameterDtos;
using Dtos.ProcessResponseDtos;
using Dtos.SessionDtos;
using Dtos.StreamDtos;

using Entities.Concrete;

namespace Business.Mappings.AutoMapper {
    public class TennisProfile : Profile {

        public TennisProfile() {
            CreateMap<PlayingDatum, PlayingDatumRelatedListDto>().ReverseMap();
            CreateMap<PlayingDatum, PlayingDatumListDto>().ReverseMap();
            CreateMap<AosType, AosTypeListDto>().ReverseMap();
            CreateMap<Stream, StreamListDto>().ReverseMap();
            CreateMap<Stream, StreamCreateDto>().ReverseMap();
            CreateMap<Player, PlayerListDto>().ReverseMap();
            CreateMap<Player, PlayerCreateDto>().ReverseMap();
            CreateMap<Court, CourtListDto>().ReverseMap();
            CreateMap<Court, CourtCreateDto>().ReverseMap();
            CreateMap<CourtType, CourtTypeListDto>().ReverseMap();
            CreateMap<Session, SessionListDto>().ReverseMap();
            CreateMap<Session, SessionCreateDto>().ReverseMap();
            CreateMap<Process, ProcessListDto>().ReverseMap();
            CreateMap<Process, ProcessCreateDto>().ReverseMap();

            CreateMap<ProcessParameter, ProcessParameterListDto>().ReverseMap();
            CreateMap<ProcessParameter, ProcessParameterCreateDto>().ReverseMap();
            CreateMap<ProcessResponse, ProcessParameterListDto>().ReverseMap();
            CreateMap<ProcessResponse, ProcessParameterCreateDto>().ReverseMap();

            CreateMap<GenerateProcessModel, ProcessParameter>();
            CreateMap<GenerateProcessModel, ProcessResponse>();
            CreateMap<GenerateProcessModel, Process>().ForMember(x => x.Id, opt => opt.Ignore());

            CreateMap<GenerateProcessModel, ProcessParameterCreateDto>();
            CreateMap<GenerateProcessModel, ProcessResponseCreateDto>();
            CreateMap<GenerateProcessModel, ProcessCreateDto>();

            CreateMap<ProcessParameterCreateDto, ProcessResponse>();
            CreateMap<ProcessResponseCreateDto, ProcessResponse>();

        }
    }
}