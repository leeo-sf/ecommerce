using MediatR;

namespace Ecommerce.Sharable.Request.Product;

public record CustomizeProductRequest(Guid ProductId, Guid? PromotionId, Guid? CouponId) : IRequest<Result>;