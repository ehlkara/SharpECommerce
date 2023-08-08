using AutoMapper;
using SharpEcommerce.API.Dtos;
using SharpEcommerce.Core.Entities;

namespace SharpEcommerce.API.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductToReturnDto>();
        }
    }
}
