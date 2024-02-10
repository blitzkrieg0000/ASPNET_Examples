using AutoMapper;
using UI.Dto.Role;
using UI.Entities.Auth;

namespace UI.Mapping.AutoMapper.Role;


public class RoleProfile : Profile {
    public RoleProfile() {
        CreateMap<ApplicationRole, RoleDto>().ReverseMap();
        CreateMap<RoleCreateDto, ApplicationRole>().ReverseMap();
    }
}
