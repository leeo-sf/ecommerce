using Ecommerce.Sharable.Config;
using Ecommerce.Sharable.Dto;
using MediatR;

namespace Ecommerce.Sharable.Request.Coupon;

[SwaggerSchemaName("TodosCupom")]
public record GetAllCouponRequest() : IRequest<Result<ICollection<CouponDto>>>;