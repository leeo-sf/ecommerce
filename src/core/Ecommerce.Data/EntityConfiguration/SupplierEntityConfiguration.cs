using Ecommerce.Data.EntityConfiguration.Base;
using Ecommerce.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Data.EntityConfiguration;

internal class SupplierEntityConfiguration : IEntityTypeConfiguration<Supplier>
{
    public void Configure(EntityTypeBuilder<Supplier> builder)
    {
        builder.ToTable("supplier");
        builder.ConfigureBaseEntities();
        builder.Property(c => c.Name).IsRequired().HasMaxLength(300).HasColumnName("name").HasComment("Nome do fornecedor");
        builder.Property(c => c.IsActive).IsRequired().HasColumnName("is_active").HasDefaultValue(false).HasComment("Fornecedor ativo no sistema");
        builder.HasMany(c => c.Addresses).WithOne().HasForeignKey("id").OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(c => c.Products).WithOne(c => c.Supplier).HasForeignKey(c => c.SupplierId).OnDelete(DeleteBehavior.Cascade);
        builder.Property(c => c.Cnpj).IsRequired().HasMaxLength(14).HasColumnName("cnpj").HasComment("CNPJ do fornecedor");
        builder.HasIndex(c => c.Cnpj);
    }
}
