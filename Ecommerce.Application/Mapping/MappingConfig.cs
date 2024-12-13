using AutoMapper;
using Ecommerce.Application.DTOs.Product;
using Ecommerce.Application.DTOs.Product.Category;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Mapping;

public class MappingConfig : Profile
{
    public MappingConfig()
    {
        CreateMap<CreateCategory, Category>();
        CreateMap<CreateProduct, Product>();
        
        
        CreateMap<Category, GetCategory>();
        CreateMap<Product, GetProduct>();
    }
}