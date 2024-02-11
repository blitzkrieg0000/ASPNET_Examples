using AutoMapper;
using UI.Dto.Auth;
using UI.Dto.Employee;
using E = UI.Entity.Concrete.Employee;

namespace UI.Mapping.AutoMapper.Employee;


public class EmployeeProfile : Profile {
    public EmployeeProfile() {
        CreateMap<E::Employee, EmployeeDto>().ReverseMap();
        CreateMap<E::Employee, EmployeeCreateDto>().ReverseMap();
        CreateMap<E::Employee, EmployeeUpdateDto>().ReverseMap();
        CreateMap<UserSignUpDto, EmployeeCreateDto>();
        
        CreateMap<EmployeeCreateDto, UserSignUpDto>()
        .ForMember(x=>x.PhoneNumber,
            opt=>opt.MapFrom(s=>s.Phone)
        ).ForMember(x=>x.Email,
            opt=>opt.MapFrom(s=>s.Mail));
    }
}
