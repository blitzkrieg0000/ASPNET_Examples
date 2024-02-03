using Application.Consts;
using Application.Dtos.User;
using Application.Dtos.UserRole;
using Application.Models.User;
using AutoMapper;
using Domain.Entities.Auth;

namespace Application.Mappings.AutoMapper.Auth;

public class ApplicationUserProfile : Profile {
    public ApplicationUserProfile() {

        CreateMap<ApplicationUser, Dtos.Auth.UserSignUpDto>();
        CreateMap<Dtos.Auth.UserSignUpDto, ApplicationUser>()
        .ForMember(x => x.Name, opt => opt.MapFrom(src => src.Username))
        .ForMember(x => x.NormalizedName, opt => opt.MapFrom(src => src.Username));


        CreateMap<ApplicationUser, UserDto>().ReverseMap();
        CreateMap<ApplicationUser, UserViewModel>()
        .ForMember(x => x.UserDto, opt => opt.MapFrom(x => x))
        .ForMember(x => x.Roles, opt => opt.MapFrom(x => x.ApplicationUserRoles
            .Where(w => x.Id == w.UserId)
            .Select(a => a.Role.Name).ToList())
        )
        .ForMember(x => x.Image, opt => opt.MapFrom(src => src.ApplicationUserClaims
        .Where(w => w.UserId == src.Id && w.ClaimType == UserDefaults.ClaimsTypes.ProfilePhoto)
        .Select(a => a.ClaimValue).FirstOrDefault()));


        CreateMap<UserUpdateDto, ApplicationUser>();
        CreateMap<ApplicationUser, UserUpdateDto>();
    }
}
