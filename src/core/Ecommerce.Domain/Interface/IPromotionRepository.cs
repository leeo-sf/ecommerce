using Ecommerce.Domain.Entity;

namespace Ecommerce.Domain.Interface;

public interface IPromotionRepository
{
    Task<Promotion> CreatePromotionAsync(Promotion promotion, CancellationToken cancellationToken);
    Task<Promotion?> GetPromotionByIdAsync(Guid id, CancellationToken cancellationToken);
}