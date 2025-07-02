using Ecommerce.Domain.Entity.Base;

namespace Ecommerce.Domain.Entity;

public record Coupon
    (Guid Id, DateTime CreatedIn, DateTime UpdatedIn, string Code, int DiscountPercentage, DateTime? ValidUntil) 
        : BaseEntity(Id, CreatedIn, UpdatedIn)
{
    public ICollection<Product> Products { get; } = default!;
}