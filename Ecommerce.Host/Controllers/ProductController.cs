using Ecommerce.Application.DTOs.Product;
using Ecommerce.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace Ecommerce.Host.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductController(IProductService productService) : ControllerBase
{
    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
        var data = await productService.GetAllAsync();
        return data.Any() ? Ok(data) : NotFound(data);
        
    }

    [HttpGet("single/{id}")]
    public async Task<IActionResult> GetSingle(Guid id)
    {
        var data = await productService.GetByIdAsync(id);
        return data != null ? Ok(data) : NotFound(data);
    }

    [HttpPost("add")]
    public async Task<IActionResult> Add(CreateProduct product)
    {
        var result = await productService.AddAsync(product);
        return result.Success ? Ok(result) : BadRequest(result);
    }
    
    
    [HttpPut("update")]
    public async Task<IActionResult> Update(UpdateProduct product)
    {
        var result = await productService.UpdateAsync(product);
        return result.Success ? Ok(result) : BadRequest(result);
    }
    
    
    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await productService.DeleteAsync(id);
        return result.Success? Ok(result) : BadRequest(result);
    }
}