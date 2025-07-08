using Ecommerce.Sharable.Config;

namespace Ecommerce.Sharable.VO;

[SwaggerSchemaName("Cupom")]
public record CouponVO(Guid Id, string Code, float DiscountPercentage, DateTime? ValidUntil) { }