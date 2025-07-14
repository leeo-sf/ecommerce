using Ecommerce.Sharable.Dto;
using MediatR;

namespace Ecommerce.Sharable.Request.Promotion;

public record CreatePromotionRequest
    (int DiscountPercentage, DateTime? PromotionStartsIn, DateTime? ValidUntil, Guid ProductId, bool IsPromotion = true) : IRequest<Result<PromotionDto>>;