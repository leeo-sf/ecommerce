using Ecommerce.Domain.Entity.Base;
using Ecommerce.Sharable.Request;

namespace Ecommerce.Domain.Entity;

public record Category
    (Guid Id, DateTime CreatedIn, DateTime UpdatedIn, string Name) : BaseEntity(Id, CreatedIn, UpdatedIn)
{
    public ICollection<Product> Products { get; } = default!;

    internal Category(CategoryRequest request)
        : this(Guid.NewGuid(), DateTime.Now, DateTime.Now, request.Name) { }
}