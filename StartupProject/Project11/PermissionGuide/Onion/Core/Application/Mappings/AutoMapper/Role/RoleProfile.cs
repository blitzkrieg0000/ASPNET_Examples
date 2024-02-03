using Application.Dtos.Role;
using AutoMapper;
using Domain.Entities.Auth;

namespace Application.Mappings.AutoMapper.Role;


public class RoleProfile : Profile {
    public RoleProfile() {
        CreateMap<ApplicationRole, RoleDto>().ReverseMap();
        CreateMap<RoleCreateDto, ApplicationRole>().ReverseMap();
    }
}
