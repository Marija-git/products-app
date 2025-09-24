using AutoMapper;
using ProductsApp.API.DTOs.Request;
using ProductsApp.API.DTOs.Response;
using ProductsApp.Data.Models;

namespace ProductsApp.API.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDtoResponse>()
                 .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.Categories));

            CreateMap<ProductDtoRequest, Product>()
            .ForMember(dest => dest.ProductId, opt => opt.Ignore())
            //.ForMember(dest => dest.CreatedAt, opt => opt.Ignore()) mogu i ovo posto sam u bazi svakako stavila default getdate
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow))
            .ForMember(dest => dest.Categories, opt => opt.Ignore());

            CreateMap<Category, CategoryDtoResponse>();
        }
    }
}
