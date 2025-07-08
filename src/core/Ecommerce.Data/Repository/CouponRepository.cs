using Ecommerce.Domain.Entity;
using Ecommerce.Domain.Interface;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Data.Repository;

public class CouponRepository : ICouponRepository
{
    private readonly AppDbContext _appDbContext;

    public CouponRepository(AppDbContext appDbContext) => _appDbContext = appDbContext;

    public async Task<bool> AlreadyExistsAsync(string code, CancellationToken cancellationToken)
        => await _appDbContext.Coupon
            .AsNoTracking()
            .AnyAsync(x => x.Code == code, cancellationToken);

    public async Task<Coupon?> CouponByIdAsync(Guid id, CancellationToken cancellationToken)
        => await _appDbContext.Coupon
            .Where(c => c.Id == id)
            .FirstOrDefaultAsync(cancellationToken);

    public async Task<ICollection<Coupon>> GetAllCouponAsync()
        => await _appDbContext.Coupon.ToListAsync();

    public async Task CreateCouponAsync(Coupon coupon, CancellationToken cancellationToken)
    {
        _appDbContext.Coupon.Add(coupon);
        await _appDbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteCouponAsync(Coupon coupon, CancellationToken cancellationToken)
    {
        _appDbContext.Coupon.Remove(coupon);
        await _appDbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<Coupon> UpdateCouponAsync(Coupon coupon, CancellationToken cancellationToken)
    {
        _appDbContext.Coupon.Update(coupon);
        await _appDbContext.SaveChangesAsync(cancellationToken);
        return coupon;
    }
}