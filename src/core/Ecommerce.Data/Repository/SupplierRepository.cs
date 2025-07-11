using Ecommerce.Domain.Entity;
using Ecommerce.Domain.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Ecommerce.Data.Repository;

public class SupplierRepository : ISupplierRepository
{
    private readonly AppDbContext _appDbContextl;

    public SupplierRepository(AppDbContext appDbContext) => _appDbContextl = appDbContext;

    public async Task<bool> SupplierAlreadyExistsAsync(Expression<Func<Supplier, bool>> condition, CancellationToken cancellationToken)
        => await _appDbContextl.Supplier
            .AsNoTracking()
            .AnyAsync(condition, cancellationToken);

    public async Task<Supplier> CreateSupplierAsync(Supplier supplier, CancellationToken cancellationToken)
    {
        _appDbContextl.Supplier.Add(supplier);
        await _appDbContextl.SaveChangesAsync(cancellationToken);
        return supplier;
    }

    public async Task UpdateSupplierAsync(Supplier supplier, CancellationToken cancellationToken)
    {
        _appDbContextl.Supplier.Update(supplier);
        await _appDbContextl.SaveChangesAsync(cancellationToken);
    }

    public async Task<Supplier?> GetSupplierByIdAsync(Guid id, CancellationToken cancellationToken)
        => await _appDbContextl.Supplier
            .AsNoTracking()
            .FirstOrDefaultAsync(s => s.Id == id);

    public async Task<ICollection<Supplier>> GetSuppliersAsync(CancellationToken cancellationToken)
        => await _appDbContextl.Supplier
            .Include(s => s.Addresses)
            .Include(s => s.Products)
            .AsNoTracking()
            .ToListAsync();
}