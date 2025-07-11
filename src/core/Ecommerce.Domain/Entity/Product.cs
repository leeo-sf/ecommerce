using Ecommerce.Domain.Entity.Base;
using Ecommerce.Sharable.Enum;

namespace Ecommerce.Domain.Entity;

public record Product
    (Guid Id, DateTime CreatedIn, DateTime UpdatedIn, string Name, string Description,
    ColorEnum Color, ICollection<string> ImagesUrl, double Price, int QuantityInStock,
    Guid SupplierId, Guid CategoryId, Guid? PromotionId, Guid? CouponId) 
        : BaseEntity(Id, CreatedIn, UpdatedIn)
{
    public Supplier Supplier { get; } = default!;
    public Category Category { get; } = default!;
    public Promotion Promotion { get; } = default!;
    public Coupon Coupon { get; } = default!;
}