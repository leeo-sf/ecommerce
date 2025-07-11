using Ecommerce.Sharable.Config;

namespace Ecommerce.Sharable.Dto;

[SwaggerSchemaName("Cupom")]
public record CouponDto(Guid Id, string Code, float DiscountPercentage, DateOnly? ValidUntil) { }