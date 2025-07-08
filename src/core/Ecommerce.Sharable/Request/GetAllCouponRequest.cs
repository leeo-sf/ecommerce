using Ecommerce.Sharable.Config;
using Ecommerce.Sharable.VO;
using MediatR;

namespace Ecommerce.Sharable.Request;

[SwaggerSchemaName("TodosCupom")]
public record GetAllCouponRequest() : IRequest<Result<ICollection<CouponVO>>>;