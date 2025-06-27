using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ecommerce.Domain.Entity.Base;

namespace Ecommerce.Domain.Entity;

[Table("product_table")]
public abstract class Product : BaseEntity
{
    [Column("name")]
    [StringLength(180)]
    public string Name { get; protected set; }

    [Column("description")]
    [StringLength(2000)]
    public string Description { get; protected set; }

    [Column("color")]
    [StringLength(20)]
    public string Color { get; protected set; }

    [Column("images_url")]
    public ICollection<string> ImagesUrl { get; protected set; }

    [Column("price")]
    [Range(5, 50000)]
    public double Price { get; protected set; }

    [Column("quantity_in_stock")]
    [Range(1, 10000)]
    public int QuantityInStock { get; protected set; }

    [ForeignKey("supplier")]
    public Guid SupplierId { get; protected set; }
    public virtual Supplier Supplier { get; protected set; }

    [ForeignKey("category")]
    public Guid CategoryId { get; protected set; }
    public virtual Category Category { get; protected set; }

    public Product() { }

    public Product(
        Guid id,
        string name,
        string description,
        string color,
        ICollection<string> imagesUrl,
        double price,
        int quantityInStock,
        Guid supplierId,
        Guid categoryId
    )
        : base(id)
    {
        Name = name;
        Description = description;
        Color = color;
        ImagesUrl = imagesUrl;
        Price = price;
        QuantityInStock = quantityInStock;
        SupplierId = supplierId;
        CategoryId = categoryId;
    }
}
