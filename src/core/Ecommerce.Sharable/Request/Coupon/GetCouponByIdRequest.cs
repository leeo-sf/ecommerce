using Ecommerce.Sharable.Config;
using Ecommerce.Sharable.Dto;
using MediatR;

namespace Ecommerce.Sharable.Request.Coupon;

[SwaggerSchemaName("CupomPorId")]
public record GetCouponByIdRequest(Guid Id) : IRequest<Result<CouponDto>>;