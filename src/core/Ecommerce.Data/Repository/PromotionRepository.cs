using Ecommerce.Domain.Entity;
using Ecommerce.Domain.Interface;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Data.Repository;

public class PromotionRepository : IPromotionRepository
{
    private readonly AppDbContext _appDbContext;

    public PromotionRepository(AppDbContext appDbContext) => _appDbContext = appDbContext;

    public async Task<Promotion> CreatePromotionAsync(Promotion promotion, CancellationToken cancellationToken)
    {
        _appDbContext.Promotion.Add(promotion);
        await _appDbContext.SaveChangesAsync(cancellationToken);
        return promotion;
    }

    public async Task<Promotion?> GetPromotionByIdAsync(Guid id, CancellationToken cancellationToken)
        => await _appDbContext.Promotion
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == id);
}