using AutoMapper;
using UI.Dto.Work;
using UI.Entity.Concrete.Work;

namespace UI.Mapping.AutoMapper.Work;


public class OffWorkProfile : Profile {

    public OffWorkProfile() {

        CreateMap<OffWorkCreateDto, OffWork>().ReverseMap();
        CreateMap<OffWorkDto, OffWork>();
        CreateMap<OffWork, OffWorkDto>()
            .ForMember(x => x.EmployeeFullName,
                opt => {
                    opt.MapFrom(x => x.Employee.FirstName + " " + x.Employee.LastName);
                }
            );

    }
    
}
