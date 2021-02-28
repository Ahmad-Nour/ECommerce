using API.DTOs;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfiles :Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product , ProductToReturnDto>()
                .ForMember(d => d.ProductBrand , e => e.MapFrom(x => x.ProductBrand.Name))
                .ForMember(d => d.ProductType , e => e.MapFrom(x => x.ProductType.Name))
                .ForMember(d => d.PictureUrl , e => e.MapFrom<ProductUrlResolver>());
        }
    }
}