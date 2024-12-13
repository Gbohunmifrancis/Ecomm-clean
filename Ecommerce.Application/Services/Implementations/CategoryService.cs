using AutoMapper;
using Ecommerce.Application.DTOs;
using Ecommerce.Application.DTOs.Product.Category;
using Ecommerce.Application.Services.Interfaces;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces;

namespace Ecommerce.Application.Services.Implementations;

public class CategoryService(IGeneric<Category> categoryInterface, IMapper mapper) : ICategoryService
{
    public async Task<ServiceResponse> AddAsync(CreateCategory category)
    {

        var mappedData = mapper.Map<Category>(category);
        int result = await categoryInterface.AddAsync(mappedData);
        return result > 0
            ? new ServiceResponse(true, "Catgory Added Succesfully!!!")
            : new ServiceResponse(false, "Category Failed to Add!!😩");
    }

    public async Task<IEnumerable<CreateCategory>> GetAllAsync()
    {
        var rawData = await categoryInterface.GetAllAsync();
        if (!rawData.Any()) return [];
        return mapper.Map<IEnumerable<CreateCategory>>(rawData);

    }

    public async Task<GetCategory> GetByIdAsync(Guid id)
    {
        var rawData = await categoryInterface.GetByIdAsync(id);
        if (rawData == null) return new GetCategory();
        return mapper.Map<GetCategory>(rawData);
    }

    public async Task<ServiceResponse> UpdateAsync(UpdateCategory category)
    {
        var mappedData = mapper.Map<Category>(category);
        int result = await categoryInterface.UpdateAsync(mappedData);
        return result > 0
            ? new ServiceResponse(true, "Category Updated Succesfully!!!")
            : new ServiceResponse(false, "Category Failed to Update!!😩");
    }

    public async Task<ServiceResponse> DeleteAsync(Guid id)
    {
        int result = await categoryInterface.DeleteAsync(id);
        if (result == 0)
            return new ServiceResponse(false, "Category Failed to be deleted");

        return result > 0
            ? new ServiceResponse(true, "Category Deleted")
            : new ServiceResponse(false, "Category not found or Failed to Delete!!😩");
    }
}
