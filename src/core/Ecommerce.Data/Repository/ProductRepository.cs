using Ecommerce.Domain.Entity;
using Ecommerce.Domain.Interface;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Data.Repository;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _appDbContext;

    public ProductRepository(AppDbContext appDbContext) => _appDbContext = appDbContext;

    public async Task<Product?> GetProductByIdAsync(Guid id, CancellationToken cancellationToken)
        => await _appDbContext.Product
            .Include(x => x.Supplier)
            .Include(x => x.Category)
            .Include(x => x.Promotion)
            .Include(x => x.Coupon)
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == id);

    public async Task<Product> CreateProductAsync(Product product, CancellationToken cancellationToken)
    {
        _appDbContext.Product.Add(product);
        await _appDbContext.SaveChangesAsync(cancellationToken);
        return product;
    }
}