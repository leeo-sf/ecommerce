using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ecommerce.Domain.Entity.Base;
using Ecommerce.Domain.Enum;

namespace Ecommerce.Domain.Entity;

[Table("address_table")]
public class Address : BaseEntity
{
    [Column("zip_code")]
    [StringLength(10)]
    public string ZipCode { get; private set; }

    [Column("public_place")]
    [StringLength(100)]
    public string PublicPlace { get; private set; }

    [Column("neighborhood")]
    [StringLength(300)]
    public string Neighborhood { get; private set; }

    [ForeignKey("uf")]
    public Guid UfId { get; private set; }
    public virtual Category Uf { get; private set; }

    public Address() { }

    public Address(Guid id, string zipCode, string publicPlace, string neighborhood, Guid ufId)
        : base(id)
    {
        ZipCode = zipCode;
        PublicPlace = publicPlace;
        Neighborhood = neighborhood;
        UfId = ufId;
    }
}
