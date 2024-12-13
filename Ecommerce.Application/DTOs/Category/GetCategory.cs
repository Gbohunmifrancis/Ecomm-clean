namespace Ecommerce.Application.DTOs.Product.Category;

public class GetCategory : CategoryBase
{
    public Guid Id { get; set; }
    public ICollection<GetProduct>? Products { get; set; }
}