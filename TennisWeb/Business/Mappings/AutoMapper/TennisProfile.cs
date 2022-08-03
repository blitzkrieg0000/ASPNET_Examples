
using AutoMapper;
using Dtos.TennisDtos;
using UI.Entities.Concrete;

namespace Business.Mappings.AutoMapper {
    public class TennisProfile : Profile {
        public TennisProfile() {
            CreateMap<PlayingDatum, PlayingDatumListDto>().ReverseMap();
        }
    }
}