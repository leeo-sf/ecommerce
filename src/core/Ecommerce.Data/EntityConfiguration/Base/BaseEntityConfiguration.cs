using Ecommerce.Domain.Entity.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Data.EntityConfiguration.Base;

internal static class BaseEntityConfiguration
{
    public static void ConfigureBaseEntities<TEntity>(this EntityTypeBuilder<TEntity> builder)
        where TEntity : BaseEntity
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasColumnName("id").IsRequired();
        builder.Property(e => e.CreatedIn).HasColumnName("created_in").IsRequired().HasComment("Data de criação");
        builder.Property(e => e.UpdatedIn).HasColumnName("updated_in").IsRequired().HasComment("Data de atualização");
    }
}