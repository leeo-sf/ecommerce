using Ecommerce.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infra.Data;

public class AppDbContext : DbContext
{
    public AppDbContext() { }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<Address> Address { get; set; }
    public DbSet<Clothing> Clothing { get; set; }
    public DbSet<Electronic> Electronic { get; set; }
    public DbSet<Supplier> Supplier { get; set; }
    public DbSet<Category> Category { get; set; }
}
