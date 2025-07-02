using Ecommerce.Data.EntityConfiguration.Base;
using Ecommerce.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Data.EntityConfiguration;

internal class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("product");
        builder.ConfigureBaseEntities();
        builder.Property(c => c.Name).IsRequired().HasMaxLength(180).HasColumnName("name").HasComment("Nome do produto");
        builder.Property(c => c.Description).HasMaxLength(2000).HasColumnName("description").HasComment("Descrição do produto");
        builder.Property(c => c.Color).IsRequired().HasConversion<string>().HasColumnName("color").HasComment("Cor do produto");
        builder.Property(c => c.ImagesUrl).IsRequired().HasColumnName("images_url").HasComment("Imagens do produto");
        builder.Property(c => c.Price).IsRequired().HasMaxLength(50000).HasColumnName("price").HasComment("Preço do produto");
        builder.Property(c => c.QuantityInStock).IsRequired().HasMaxLength(10000).HasColumnName("quantity_in_stock").HasComment("Quantidade de produtos no estoque");
        builder.Property(c => c.SupplierId).IsRequired().HasColumnName("supplier_id").HasComment("Identificador do fornecedor");
        builder.Property(c => c.CategoryId).IsRequired().HasColumnName("category_id").HasComment("Identificador da Categoria");
        builder.Property(c => c.PromotionId).HasColumnName("promotion_id").HasComment("Identificador da Promoção");
        builder.Property(c => c.CouponId).HasColumnName("coupon_id").HasComment("Identificador do Cupom");
        builder.HasOne(c => c.Supplier).WithMany(c => c.Products).HasForeignKey(c => c.SupplierId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(c => c.Category).WithMany(c => c.Products).HasForeignKey(c => c.CategoryId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(c => c.Promotion).WithMany(c => c.Products).HasForeignKey(c => c.PromotionId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(c => c.Coupon).WithMany(c => c.Products).HasForeignKey(c => c.CouponId).OnDelete(DeleteBehavior.Cascade);
    }
}
