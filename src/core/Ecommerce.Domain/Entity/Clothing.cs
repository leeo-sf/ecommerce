using System.ComponentModel.DataAnnotations.Schema;
using Ecommerce.Domain.Enum;

namespace Ecommerce.Domain.Entity;

[Table("clothing_table")]
public class Clothing : Product
{
    [ForeignKey("size")]
    public Guid SizeId { get; private set; }
    public virtual Category Size { get; private set; }

    [ForeignKey("clothing_category")]
    public Guid ClothingCategoryId { get; private set; }
    public virtual Category ClothingCategory { get; private set; }

    [ForeignKey("tissue")]
    public Guid TissueId { get; private set; }
    public virtual Category Tissue { get; private set; }

    public Clothing() { }

    public Clothing(Product product, Guid sizeId, Guid clothingCatyegoryId, Guid tissueId)
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
        SizeId = sizeId;
        ClothingCategoryId = clothingCatyegoryId;
        TissueId = tissueId;
    }
}
