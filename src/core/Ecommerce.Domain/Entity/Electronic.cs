using System.ComponentModel.DataAnnotations.Schema;
using Ecommerce.Domain.Enum;

namespace Ecommerce.Domain.Entity;

[Table("electronic_table")]
public class Electronic : Product
{
    [ForeignKey("type")]
    public Guid TypeId { get; private set; }
    public virtual Category Type { get; private set; }

    public Electronic() { }

    public Electronic(Product product, Guid typeId)
        : base(
            product.Id,
            product.Name,
            product.Description,
            product.Color,
            product.ImagesUrl,
            product.Price,
            product.QuantityInStock,
            product.SupplierId,
            product.CategoryId
        )
    {
        TypeId = typeId;
    }
}
