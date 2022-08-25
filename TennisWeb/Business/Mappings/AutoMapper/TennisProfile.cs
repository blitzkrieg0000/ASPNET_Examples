using AutoMapper;
using Dtos.AosTypeDtos;
using Dtos.CourtDtos;
using Dtos.CourtTypeDtos;
using Dtos.GRPCData;
using Dtos.PlayerDtos;
using Dtos.PlayingDatumDtos;
using Dtos.ProcessDtos;
using Dtos.SessionParameterDtos;
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
            CreateMap<Player, PlayerListRelatedDto>().ReverseMap();
            CreateMap<Court, CourtListDto>().ReverseMap();
            CreateMap<Court, CourtListRelatedDto>().ReverseMap();
            CreateMap<Court, CourtCreateDto>().ReverseMap();
            CreateMap<CourtType, CourtTypeListDto>().ReverseMap();
            CreateMap<Session, SessionListDto>().ReverseMap();
            CreateMap<Session, SessionCreateDto>().ReverseMap();
            CreateMap<Process, ProcessListDto>().ReverseMap();
            CreateMap<Process, ProcessCreateDto>().ReverseMap();

            CreateMap<SessionParameter, SessionParameterListDto>().ReverseMap();
            CreateMap<SessionParameter, SessionParameterCreatetDto>().ReverseMap();
            CreateMap<ProcessResponse, SessionParameterListDto>().ReverseMap();
            CreateMap<ProcessResponse, SessionParameterCreatetDto>().ReverseMap();

            CreateMap<GenerateProcessModel, SessionParameter>();
            CreateMap<GenerateProcessModel, ProcessResponse>();
            CreateMap<GenerateProcessModel, Process>().ForMember(x => x.Id, opt => opt.Ignore());

            CreateMap<GenerateProcessModel, SessionParameterCreatetDto>();
            CreateMap<GenerateProcessModel, ProcessResponseCreateDto>();
            CreateMap<GenerateProcessModel, ProcessCreateDto>();

            CreateMap<SessionParameterCreatetDto, ProcessResponse>();
            CreateMap<ProcessResponseCreateDto, ProcessResponse>();

        }
    }
}