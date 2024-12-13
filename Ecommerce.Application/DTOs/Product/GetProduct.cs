using Ecommerce.Application.DTOs.Product.Category;

namespace Ecommerce.Application.DTOs.Product;

public class GetProduct : ProductBase
{
    public Guid Id { get; set; }
    public GetCategory? Category { get; set; }
}