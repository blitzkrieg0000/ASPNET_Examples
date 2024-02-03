using Application.Dtos.UserRole;
using AutoMapper;
using Domain.Entities.Auth;

namespace Application.Mappings.AutoMapper.Auth;


public class ApplicationRoleProfile : Profile {
    public ApplicationRoleProfile() {
        CreateMap<ApplicationUserRole, UserRoleAuthDto>().ReverseMap();
        CreateMap<ApplicationUserRole, UserRoleDto>().ReverseMap();
    }
    
}
