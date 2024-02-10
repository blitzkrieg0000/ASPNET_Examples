using AutoMapper;
using UI.Dto.UserRole;
using UI.Entities.Auth;


namespace UI.Mapping.AutoMapper.Auth;


public class ApplicationRoleProfile : Profile {
    public ApplicationRoleProfile() {
        CreateMap<ApplicationUserRole, UserRoleAuthDto>().ReverseMap();
        CreateMap<ApplicationUserRole, UserRoleDto>().ReverseMap();
    }
    
}
