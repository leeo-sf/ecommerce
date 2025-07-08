using Ecommerce.Data.EntityConfiguration;
using Ecommerce.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<Address> Address { get; set; } = default!;
    public DbSet<Supplier> Supplier { get; set; } = default!;
    public DbSet<Category> Category { get; set; } = default!;
    public DbSet<Product> Product { get; set; } = default!;
    public DbSet<Coupon> Coupon { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CategoryEntityConfiguration());
        modelBuilder.ApplyConfiguration(new AddressEntityConfiguration());
        modelBuilder.ApplyConfiguration(new ProductEntityConfiguration());
        modelBuilder.ApplyConfiguration(new SupplierEntityConfiguration());
        modelBuilder.ApplyConfiguration(new PromotionEntityConfiguration());
        modelBuilder.ApplyConfiguration(new CouponEntityConfiguration());
    }
}
