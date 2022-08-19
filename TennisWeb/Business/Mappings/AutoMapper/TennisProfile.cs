using AutoMapper;
using Dtos.AOSTypeDtos;
using Dtos.CourtDtos;
using Dtos.PlayerDtos;
using Dtos.PlayingDatumDtos;
using Dtos.StreamDtos;
using Dtos.TennisDtos;
using UI.Entities.Concrete;

namespace Business.Mappings.AutoMapper {
    public class TennisProfile : Profile {
        public TennisProfile() {
            CreateMap<PlayingDatum, PlayingDatumRelatedListDto>().ReverseMap();
            CreateMap<Stream, StreamCreateDto>().ReverseMap();
            CreateMap<Aostype, AOSTypeListDto>().ReverseMap();
            CreateMap<Stream, StreamListDto>().ReverseMap();
            CreateMap<Player, PlayerListDto>().ReverseMap();
            CreateMap<Court, CourtListDto>().ReverseMap();
        }
    }
}