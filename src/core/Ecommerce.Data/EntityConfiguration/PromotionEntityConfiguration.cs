using Ecommerce.Data.EntityConfiguration.Base;
using Ecommerce.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Data.EntityConfiguration;

internal class PromotionEntityConfiguration : IEntityTypeConfiguration<Promotion>
{
    public void Configure(EntityTypeBuilder<Promotion> builder)
    {
        builder.ToTable("promotion");
        builder.ConfigureBaseEntities();
        builder.Property(c => c.IsPromotion).IsRequired().HasDefaultValue(false).HasColumnName("is_promotion").HasComment("Produto está em promoção");
        builder.Property(c => c.OriginalValue).HasColumnName("original_value").HasComment("Valor original do produto");
        builder.Property(c => c.DiscountPercentage).HasColumnName("discount_percentage").HasComment("Porcentagem do desconto");
        builder.Property(c => c.ValidUntil).HasColumnName("valid_until").HasComment("Data de validade do cupom de desconto");
        builder.Property(c => c.DiscountAmount).HasColumnName("discount_amount").HasComment("Valor do desconto");
    }
}
