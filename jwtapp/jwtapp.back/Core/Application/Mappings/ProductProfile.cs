using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using jwtapp.back.Core.Application.Dto;
using jwtapp.back.Core.Domain;

namespace jwtapp.back.Core.Application.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product,ProductListDto>().ReverseMap();
        
        }
    }
}