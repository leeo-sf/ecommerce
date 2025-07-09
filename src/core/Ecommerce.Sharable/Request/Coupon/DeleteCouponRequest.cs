using MediatR;

namespace Ecommerce.Sharable.Request.Coupon;

public record DeleteCouponRequest(Guid Id) : IRequest<Result>;