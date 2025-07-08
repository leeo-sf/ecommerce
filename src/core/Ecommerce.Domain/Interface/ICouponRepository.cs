using Ecommerce.Domain.Entity;

namespace Ecommerce.Domain.Interface;

public interface ICouponRepository
{
    Task<Coupon?> CouponByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<ICollection<Coupon>> GetAllCouponAsync();
    Task CreateCouponAsync(Coupon coupon, CancellationToken cancellationToken);
    Task<bool> AlreadyExistsAsync(string code, CancellationToken cancellationToken);
    Task DeleteCouponAsync(Coupon coupon, CancellationToken cancellationToken);
    Task<Coupon> UpdateCouponAsync(Coupon coupon, CancellationToken cancellationToken);
}