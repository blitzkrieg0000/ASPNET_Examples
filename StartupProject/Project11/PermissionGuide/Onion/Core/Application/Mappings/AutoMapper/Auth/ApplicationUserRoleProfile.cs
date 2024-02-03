using Application.Consts;
using Application.Dtos.UserRole;
using AutoMapper;
using Domain.Entities.Auth;

namespace Application.Mappings.AutoMapper.Auth;


public class ApplicationUserRoleProfile : Profile {
    public ApplicationUserRoleProfile() {

        CreateMap<ApplicationUserRole, UserRoleDto>()
            .ForMember(x => x.UserName, opt => opt.MapFrom(x => x.User.Name))
            .ForMember(x => x.Image, opt => opt.MapFrom(src => src.User.ApplicationUserClaims
            .Where(w => w.UserId == src.UserId && w.ClaimType == UserDefaults.ClaimsTypes.ProfilePhoto)
            .Select(a => a.ClaimValue).FirstOrDefault()));
    }
}
