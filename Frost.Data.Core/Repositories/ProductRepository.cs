using Frost.Domain.Core.Entities.Products;
using Frost.Domain.Core.Repositories.Base;
using Frost.Domain.Core.Repositories.ProductRepository;

namespace Frost.Data.Core.Repositories;

public class ProductRepository : IProductRepository
{
    public Task<Product> GetItemAsync(Guid id, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<Product?> GetNullableItemAsync(Guid id, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<Product?> GetNullableItemAsync(ISpecification<Product> specification, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<Product>> GetCollectionAsync(IReadOnlyList<Guid> ids, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<IPaginatedCollection<Product>> GetPaginatedCollectionAsync(ISpecification<Product> specification,
        int pageNumber, int pageSize, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<Product>> GetCollectionAsync(ISpecification<Product> specification, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(Product entity, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Product entity, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<Product>> GetExpiredAsync(CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<Product>> GetExpiringSoonAsync(int days = 3, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<Product>> GetByStorageLocationAsync(Guid storageLocationId, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }
}