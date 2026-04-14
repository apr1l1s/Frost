using Frost.Domain.Core.Entity.Products;
using Frost.Domain.Core.Repositories.Base;
using Frost.Domain.Core.Repositories.Products;
using Microsoft.EntityFrameworkCore;

namespace Frost.Data.Core.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly FrostDbContext _context;

    public ProductRepository(FrostDbContext context)
    {
        _context = context;
    }

    public async Task<Product?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        return await _context.Products
            .Include(p => p.Category)
            .FirstOrDefaultAsync(p => p.Id == id, ct);
    }

    public async Task<IReadOnlyList<Product>> GetAllAsync(CancellationToken ct = default)
    {
        return await _context.Products
            .Include(p => p.Category)
            .AsNoTracking()
            .ToListAsync(ct);
    }

    public async Task<IReadOnlyList<Product>> GetBySpecificationAsync(
        ISpecification<Product> spec,
        CancellationToken ct = default)
    {
        var query = _context.Products.AsQueryable();

        // Применяем фильтр
        if (spec.Criteria != null)
            query = query.Where(spec.Criteria);

        // Подгружаем навигационные свойства
        foreach (var include in spec.Includes)
            query = query.Include(include);

        // Сортировка
        if (spec.OrderBy != null)
            query = query.OrderBy(spec.OrderBy);
        else
            query = query.OrderByDescending(p => p.ModifiedDate);

        if (spec.AsNoTracking)
            query = query.AsNoTracking();

        return await query.ToListAsync(ct);
    }

    public async Task AddAsync(Product product, CancellationToken ct = default)
    {
        await _context.Products.AddAsync(product, ct);
        await _context.SaveChangesAsync(ct);
    }

    public async Task UpdateAsync(Product product, CancellationToken ct = default)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync(ct);
    }

    public async Task DeleteAsync(Guid id, CancellationToken ct = default)
    {
        var product = await _context.Products.FindAsync([id], ct);
        if (product != null)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync(ct);
        }
    }

    // Удобные методы
    public async Task<IReadOnlyList<Product>> GetExpiredAsync(CancellationToken ct = default)
    {
        return await GetBySpecificationAsync(new ExpiredProductsSpec(), ct);
    }

    // public async Task<IReadOnlyList<Product>> GetExpiringSoonAsync(int days = 3, CancellationToken ct = default)
    // {
    //     return await GetBySpecificationAsync(new ExpiringSoonProductsSpec(days), ct);
    // }
    //
    // public async Task<IReadOnlyList<Product>> GetByStorageLocationAsync(Guid storageLocationId, CancellationToken ct = default)
    // {
    //     return await GetBySpecificationAsync(new ProductByStorageLocationSpec(storageLocationId), ct);
    // }
}