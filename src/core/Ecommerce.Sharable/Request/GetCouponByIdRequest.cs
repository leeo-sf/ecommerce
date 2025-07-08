using Ecommerce.Sharable.Config;
using Ecommerce.Sharable.VO;
using MediatR;

namespace Ecommerce.Sharable.Request;

[SwaggerSchemaName("CupomPorId")]
public record GetCouponByIdRequest(Guid Id) : IRequest<Result<CouponVO>>;