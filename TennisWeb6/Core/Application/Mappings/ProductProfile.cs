using AutoMapper;
using TennisWeb6.Core.Application.Dtos;
using TennisWeb6.Core.Domains;

namespace TennisWeb6.Core.Application.Mappings {
    public class ProductProfile : Profile {
        public ProductProfile() {
            this.CreateMap<Product, ProductListDto>().ReverseMap();
        
        }
    }
}