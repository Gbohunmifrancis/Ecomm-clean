using Ecommerce.Application.DTOs;
using Ecommerce.Application.DTOs.Product.Category;

namespace Ecommerce.Application.Services.Interfaces;

public interface ICategoryService
{
    Task<IEnumerable<CreateCategory>> GetAllAsync();
    Task<GetCategory> GetByIdAsync(Guid id);
    Task<ServiceResponse> AddAsync(CreateCategory category);
    Task<ServiceResponse> UpdateAsync(UpdateCategory category);
    Task<ServiceResponse> DeleteAsync(Guid id);
}