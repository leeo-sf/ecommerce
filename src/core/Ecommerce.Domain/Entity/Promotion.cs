using Ecommerce.Domain.Entity.Base;

namespace Ecommerce.Domain.Entity;

public record Promotion
    (Guid Id, DateTime CreatedIn, DateTime UpdatedIn, bool IsPromotion, int DiscountPercentage, DateTime? PromotionStartsIn, DateTime? ValidUntil, Guid ProductId)
        : BaseEntity(Id, CreatedIn, UpdatedIn)
{
    public Product Product { get; init; } = default!;
    public float DiscountAmount { get; private set; } = default!;
    public double OriginalValue { get; private set; } = default!;

    public void DefineDiscountAmount(Promotion promotion)
        => DiscountAmount = (float)(promotion.DiscountPercentage / 100 * promotion.OriginalValue);

    public void DefineOriginalValue(Product product)
        => OriginalValue = product.Price;
}