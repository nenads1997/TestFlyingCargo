using Entities;
using Services.ServiceContracts.DTO;
using AutoMapper;

namespace FlyngCargo.API.Mappings
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductDTO, Product>()
              .ForMember(dest=>dest.CreatedAt,opt=>opt.Ignore())
            .ReverseMap();
            //CreateMap<ProductRequest, Product>()  
            //    .ForMember(dest => dest.CreatedAt, opt => opt.Ignore()); 
            //CreateMap<Product, ProductRequest>().ReverseMap();
        }
    }
}
