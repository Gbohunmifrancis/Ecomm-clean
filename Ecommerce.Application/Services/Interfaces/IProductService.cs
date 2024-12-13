using Ecommerce.Application.DTOs;
using Ecommerce.Application.DTOs.Product;

namespace Ecommerce.Application.Services.Interfaces;

public interface IProductService
{
    Task<IEnumerable<GetProduct>> GetAllAsync();
    Task<GetProduct> GetByIdAsync(Guid id);
    Task<ServiceResponse> AddAsync(CreateProduct product);
    Task<ServiceResponse> UpdateAsync(UpdateProduct product);
    Task<ServiceResponse> DeleteAsync(Guid id);
}