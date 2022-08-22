using AutoMapper;
using Dtos.AosTypeDtos;
using Dtos.CourtDtos;
using Dtos.CourtTypeDtos;
using Dtos.PlayerDtos;
using Dtos.PlayingDatumDtos;
using Dtos.ProcessDtos;
using Dtos.SessionDtos;
using Dtos.StreamDtos;

using UI.Entities.Concrete;

namespace Business.Mappings.AutoMapper {
    public class TennisProfile : Profile {
        public TennisProfile() {
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
            CreateMap<Process, ProcessCreateDto>().ReverseMap();
        }
    }
}