using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ecommerce.Domain.Entity.Base;

namespace Ecommerce.Domain.Entity;

[Table("supplier_tables")]
public class Supplier : BaseEntity
{
    [Column("name")]
    [StringLength(300)]
    public string Name { get; }

    [Column("cnpj")]
    [StringLength(14)]
    public string Cnpj { get; }

    [ForeignKey("address")]
    public Guid AddressId { get; }
    public bool IsActive { get; }
    public virtual ICollection<Product> Products { get; }

    public Supplier() { }

    public Supplier(Guid id, string name, string cnpj, Guid addressId, bool isActive)
        : base(id)
    {
        Name = name;
        Cnpj = cnpj;
        AddressId = addressId;
        IsActive = isActive;
    }
}
