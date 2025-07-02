using Ecommerce.Domain.Entity.Base;

namespace Ecommerce.Domain.Entity;

public record Promotion
    (Guid Id, DateTime CreatedIn, DateTime UpdatedIn, bool IsPromotion, float? OriginalValue, int? DiscountPercentage, DateTime? ValidUntil)
        : BaseEntity(Id, CreatedIn, UpdatedIn)
{
    public float? DiscountAmount { get; private set; } = DiscountPercentage / 100 * OriginalValue;
    public ICollection<Product> Products { get; } = default!;
}