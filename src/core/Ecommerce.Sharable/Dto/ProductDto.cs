using Ecommerce.Sharable.Enum;

namespace Ecommerce.Sharable.Dto;

public record ProductDto(Guid Id, string Name, string Description, ColorEnum Color, ICollection<string> ImagesUrl,
    double Price, int QuantityInStock, SupplierDto Supplier, CategoryDto Category,
    PromotionDto? Promotion, CouponDto? Coupon);