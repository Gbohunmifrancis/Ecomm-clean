using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Application.DTOs.Product.Category;

public class CategoryBase
{
    [Required]
    public string? Name { get; set; }
}