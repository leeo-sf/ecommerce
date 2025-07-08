using MediatR;

namespace Ecommerce.Sharable.Request;

public record DeleteCouponRequest(Guid Id) : IRequest<Result>;