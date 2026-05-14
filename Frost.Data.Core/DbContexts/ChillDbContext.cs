using Frost.Domain.Core.Entities.Products;
using Microsoft.EntityFrameworkCore;

namespace Frost.Data.Core.DbContexts;

public class ChillDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    public ChillDbContext()
    {
        Console.WriteLine("ChillDbContext");
    }
}