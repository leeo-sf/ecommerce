using Ecommerce.Data.EntityConfiguration.Base;
using Ecommerce.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Data.EntityConfiguration;

internal class CouponEntityConfiguration : IEntityTypeConfiguration<Coupon>
{
    public void Configure(EntityTypeBuilder<Coupon> builder)
    {
        builder.ToTable("coupon");
        builder.ConfigureBaseEntities();
        builder.HasIndex(c => c.Code);
        builder.Property(c => c.Code).IsRequired().HasColumnName("code").HasComment("Código do cupom");
        builder.Property(c => c.DiscountPercentage).IsRequired().HasColumnName("discount_percentage").HasComment("Porcentagem do desconto");
        builder.Property(c => c.ValidUntil).HasColumnName("valid_until").HasComment("Data de validade do cupom de desconto");
    }
}
