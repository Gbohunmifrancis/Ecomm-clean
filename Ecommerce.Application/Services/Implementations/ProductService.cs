using AutoMapper;
using Ecommerce.Application.DTOs;
using Ecommerce.Application.DTOs.Product;
using Ecommerce.Application.Services.Interfaces;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces;

namespace Ecommerce.Application.Services.Implementations;

public class ProductService(IGeneric<Product> productInterface, IMapper mapper) : IProductService
{
    public async Task<ServiceResponse> AddAsync(CreateProduct product)
    {
        var mappedData = mapper.Map<Product>(product);https://xd.complycube.com/AMEL4L3I
        int result = await productInterface.AddAsync(mappedData);
        return result > 0 ? new ServiceResponse(true, "Product Added Succesfully!!!"):
            new ServiceResponse(false, "Product Failed to Add!!😩");
        
    }

    public async Task<ServiceResponse> DeleteAsync(Guid id)
    {
        int result = await productInterface.DeleteAsync(id);
        if (result == 0)
            return new ServiceResponse(false, "Product Failed to be deleted");

        return result > 0
            ? new ServiceResponse(true, "Product Deleted")
            : new ServiceResponse(false, "Product Failed to Delete!!😩");
    }
    
    
    public async Task<IEnumerable<GetProduct>> GetAllAsync()
    {
        var rawData = await productInterface.GetAllAsync();
        if (!rawData.Any()) return [];
        return mapper.Map<IEnumerable<GetProduct>>(rawData);
    }

    public async Task<GetProduct> GetByIdAsync(Guid id)
    {
        var rawData = await productInterface.GetByIdAsync(id);
        if (rawData == null) return new GetProduct();
        return mapper.Map<GetProduct>(rawData);
    }


    public async Task<ServiceResponse> UpdateAsync(UpdateProduct product)
    {
        var mappedData = mapper.Map<Product>(product);
        int result = await productInterface.UpdateAsync(mappedData);
        return result > 0 ? new ServiceResponse(true, "Product Updated Succesfully!!!"):
            new ServiceResponse(false, "Product Failed to Update!!😩");
    }

   
}