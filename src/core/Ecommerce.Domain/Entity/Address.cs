using Ecommerce.Domain.Entity.Base;
using Ecommerce.Sharable.Enum;

namespace Ecommerce.Domain.Entity;

public record Address
    (Guid Id, DateTime CreatedIn, DateTime UpdatedIn, string ZipCode, string PublicPlace, string Neighborhood, int Number, UfEnum Uf, Guid SupplierId) 
        : BaseEntity(Id, CreatedIn, UpdatedIn)
{
    public Supplier Supplier { get; } = default!;
}