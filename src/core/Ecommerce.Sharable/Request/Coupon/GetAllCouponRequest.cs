using Ecommerce.Sharable.Config;
using Ecommerce.Sharable.VO;
using MediatR;

namespace Ecommerce.Sharable.Request.Coupon;

[SwaggerSchemaName("TodosCupom")]
public record GetAllCouponRequest() : IRequest<Result<ICollection<CouponVO>>>;