using Ecommerce.Domain.Entity.Base;
using Ecommerce.Domain.Enum;

namespace Ecommerce.Domain.Entity;

public record Address
    (Guid Id, DateTime CreatedIn, DateTime UpdatedIn, string ZipCode, string PublicPlace, string Neighborhood, UfEnum Uf) : BaseEntity(Id, CreatedIn, UpdatedIn) { }