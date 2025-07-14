namespace Ecommerce.Sharable.Dto;

public record PromotionDto
    (Guid Id, bool IsPromotion, int DiscountPercentage, float DiscountAmount, double OriginalValue, DateTime PromotionStartsIn, DateTime ValidUntil, Guid ProductId);