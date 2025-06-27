using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Domain.Entity.Base;

public class BaseEntity
{
    [Key]
    [Column("id")]
    public Guid Id { get; protected set; }

    protected BaseEntity()
    {
        Id = Guid.NewGuid();
    }

    public BaseEntity(Guid id)
    {
        Id = id;
    }
}
