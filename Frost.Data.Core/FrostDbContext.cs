using Frost.Domain.Core.Entity.Products;
using Microsoft.EntityFrameworkCore;

namespace Frost.Data.Core;

public class FrostDbContext(DbContextOptions<FrostDbContext> options)
    : DbContext(options)
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<StorageLocation> StorageLocations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(FrostDbContext).Assembly);
    }
}