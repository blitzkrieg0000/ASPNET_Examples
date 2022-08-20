using AutoMapper;
using Dtos.AosTypeDtos;
using Dtos.CourtDtos;
using Dtos.PlayerDtos;
using Dtos.PlayingDatumDtos;
using Dtos.StreamDtos;

using UI.Entities.Concrete;

namespace Business.Mappings.AutoMapper {
    public class TennisProfile : Profile {
        public TennisProfile() {
            CreateMap<PlayingDatum, PlayingDatumRelatedListDto>().ReverseMap();
            CreateMap<Stream, StreamCreateDto>().ReverseMap();
            CreateMap<AosType, AosTypeListDto>().ReverseMap();
            CreateMap<Stream, StreamListDto>().ReverseMap();
            CreateMap<Player, PlayerListDto>().ReverseMap();
            CreateMap<Court, CourtListDto>().ReverseMap();
        }
    }
}