using Ecommerce.Data.EntityConfiguration.Base;
using Ecommerce.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Data.EntityConfiguration;

internal class AddressEntityConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable("address");
        builder.ConfigureBaseEntities();
        builder.Property(c => c.ZipCode).IsRequired().HasColumnName("zip_code").HasComment("CEP");
        builder.Property(c => c.PublicPlace).IsRequired().HasColumnName("public_place").HasComment("Logradouro");
        builder.Property(c => c.Neighborhood).IsRequired().HasColumnName("neighborhood").HasComment("Bairro");
        builder.Property(c => c.Uf)
            .IsRequired()
            .HasConversion<string>()
            .HasColumnName("uf")
            .HasComment("Estado");
    }
}
