
using AutoMapper;
using Dtos.WorkDtos;
using Entities.Concrete;

namespace Business.Mappings.AutoMapper {
    public class WorkProfile : Profile {

        public WorkProfile() {
            CreateMap<Work, WorkListDto>().ReverseMap();
            CreateMap<Work, WorkCreateDto>().ReverseMap();
            CreateMap<Work, WorkUpdateDto>().ReverseMap();
            CreateMap<WorkListDto, WorkUpdateDto>().ReverseMap();
        }
    }
}