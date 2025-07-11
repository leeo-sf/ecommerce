using Ecommerce.Domain.Entity;
using System.Linq.Expressions;

namespace Ecommerce.Domain.Interface;

public interface ISupplierRepository
{
    Task<bool> SupplierAlreadyExistsAsync(Expression<Func<Supplier, bool>> condition, CancellationToken cancellationToken);
    Task<Supplier> CreateSupplierAsync(Supplier supplier, CancellationToken cancellationToken);
    Task UpdateSupplierAsync(Supplier supplier, CancellationToken cancellationToken);
    Task<Supplier?> GetSupplierByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<ICollection<Supplier>> GetSuppliersAsync(CancellationToken cancellationToken);
}