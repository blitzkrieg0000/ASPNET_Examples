using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using jwtapp.back.Core.Application.Dto;
using jwtapp.back.Core.Domain;

namespace jwtapp.back.Core.Application.Mappings
{
    public class AppUserProfile : Profile
    {
        public AppUserProfile()
        {
            CreateMap<AppUser,AppUserListDto>().ReverseMap();
        }
    }
}