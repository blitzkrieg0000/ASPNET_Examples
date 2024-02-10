using AutoMapper;
using UI.Dto.Employee;
using E = UI.Entity.Concrete.Employee;

namespace UI.Mapping.AutoMapper.Employee;


public class EmployeeProfile : Profile {
    public EmployeeProfile() {
        CreateMap<E::Employee, EmployeeDto>().ReverseMap();
        CreateMap<E::Employee, EmployeeCreateDto>().ReverseMap();
        CreateMap<E::Employee, EmployeeUpdateDto>().ReverseMap();
    }
}
