using AutoMapper;

using UI.Dto.UserRole;
using UI.Entities.Auth;

namespace UI.Mapping.AutoMapper.Auth;


public class ApplicationUserRoleProfile : Profile {
    public ApplicationUserRoleProfile() {

        CreateMap<ApplicationUserRole, UserRoleDto>()
            .ForMember(x => x.UserName, opt => opt.MapFrom(x => x.User.Username))
            .ForMember(x => x.RoleName, opt => opt.MapFrom(x => x.Role.Name));
    }
}
