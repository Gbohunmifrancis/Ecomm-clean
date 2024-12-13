using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Application.DTOs.Product.Category;

public class UpdateCategory : CategoryBase
{
    [Required]
    public Guid Id { get; set; }
}