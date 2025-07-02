using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Domain.Entity.Base;

public record BaseEntity(
    [property: NotMapped] Guid id,
    [property: NotMapped] DateTime createdIn,
    [property: NotMapped] DateTime updatedIn)
{
    public Guid Id { get; private set; } = id;
    public DateTime CreatedIn { get; private set; } = createdIn;
    public DateTime UpdatedIn { get; protected set; } = updatedIn;
}