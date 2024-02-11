using AutoMapper;
using UI.Dto.EmployeeType;
using E=UI.Entity.Concrete.Employee;
namespace UI.Mapping.AutoMapper.EmployeeType;


public class EmployeeTypeProfile : Profile {

    public EmployeeTypeProfile() {
        CreateMap<E::EmployeeType, EmployeeTypeDto>().ReverseMap();

    }

}
