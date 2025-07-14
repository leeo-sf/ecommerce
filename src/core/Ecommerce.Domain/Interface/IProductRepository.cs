using Ecommerce.Domain.Entity;

namespace Ecommerce.Domain.Interface;

public interface IProductRepository
{
    Task<Product?> GetProductByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<Product> CreateProductAsync(Product product, CancellationToken cancellationToken);
}