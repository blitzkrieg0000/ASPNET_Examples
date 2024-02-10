using AutoMapper;
using UI.Dto.Auth;
using UI.Dto.User;
using UI.Entities.Auth;
using UI.Model.User;

namespace UI.Mapping.AutoMapper.Auth;

public class ApplicationUserProfile : Profile {
    public ApplicationUserProfile() {

        CreateMap<ApplicationUser, UserSignUpDto>();
        CreateMap<UserSignUpDto, ApplicationUser>();

        CreateMap<ApplicationUser, UserDto>().ReverseMap();
        CreateMap<ApplicationUser, UserViewModel>()
        .ForMember(x => x.UserDto, opt => opt.MapFrom(x => x))
        .ForMember(x => x.Roles, opt => opt.MapFrom(x => x.ApplicationUserRoles
            .Where(w => x.Id == w.UserId)
            .Select(a => a.Role.Name).ToList())
        );

        CreateMap<UserUpdateDto, ApplicationUser>();
        CreateMap<ApplicationUser, UserUpdateDto>();
    }
}
