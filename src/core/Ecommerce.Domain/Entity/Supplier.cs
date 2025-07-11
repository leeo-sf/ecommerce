using Ecommerce.Domain.Entity.Base;

namespace Ecommerce.Domain.Entity;

public record Supplier
    (Guid Id, DateTime CreatedIn, DateTime UpdatedIn, string Name, string Cnpj, bool IsActive)
        : BaseEntity(Id, CreatedIn, UpdatedIn)
{
    public ICollection<Address> Addresses { get; init; } = new List<Address>();
    public ICollection<Product> Products { get; init; } = new List<Product>();
}