using AutoMapper;
using Dtos.AosTypeDtos;
using Dtos.CourtDtos;
using Dtos.CourtTypeDtos;
using Dtos.PlayerDtos;
using Dtos.PlayingDatumDtos;
using Dtos.ProcessDtos;
using Dtos.ProcessResponseDtos;
using Dtos.SessionDtos;
using Dtos.SessionParameterDtos;
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

            CreateMap<Process, ProcessListDto>().ReverseMap();
            CreateMap<ProcessResponse, ProcessResponseListDto>().ReverseMap();
            CreateMap<SessionCreateDto, Session>().ForMember(dst => dst.SessionParameter,
                opt => opt.MapFrom(src => new SessionParameter() {
                    StreamId = src.StreamId,
                    AosTypeId = src.AOSTypeId,
                    PlayerId = src.PlayerId,
                    CourtId = src.CourtId,
                    Limit = src.Limit,
                    Force = src.Force
                }));

            CreateMap<ProcessCreateDto, Process>().ForMember(dst => dst.ProcessParameter,
                opt => opt.MapFrom(src => new ProcessParameter() {
                    StreamId = src.StreamId,
                    Limit = src.Limit
                })).ForMember(dst => dst.ProcessResponse, opt => opt.MapFrom(src => new ProcessResponse()));

            CreateMap<SessionParameter, PlayingDatum>();
            CreateMap<SessionParameter, PlayingDatumCreateDto>().ReverseMap();
            CreateMap<PlayingDatumCreateDto, PlayingDatum>().ReverseMap();

        }
    }
}