using Frost.Domain.Core.Entity.Products;
using Frost.Domain.Core.Repositories.Base;

namespace Frost.Domain.Core.Repositories.Products;

public interface IProductRepository
{
    public interface IProductRepository
    {
        Task<Product?> GetByIdAsync(Guid id, CancellationToken ct = default);

        Task<IReadOnlyList<Product>> GetAllAsync(CancellationToken ct = default);

        Task AddAsync(Product product, CancellationToken ct = default);

        Task UpdateAsync(Product product, CancellationToken ct = default);

        Task DeleteAsync(Guid id, CancellationToken ct = default);

        Task<IReadOnlyList<Product>> GetBySpecificationAsync(ISpecification<Product> specification,
            CancellationToken ct = default);

        Task<IReadOnlyList<Product>> GetExpiredAsync(CancellationToken ct = default);

        Task<IReadOnlyList<Product>> GetExpiringSoonAsync(int daysThreshold = 3, CancellationToken ct = default);

        Task<IReadOnlyList<Product>> GetByStorageLocationAsync(Guid storageLocationId, CancellationToken ct = default);

        Task<int> CountAsync(ISpecification<Product> specification, CancellationToken ct = default);

        Task<bool> ExistsAsync(Guid id, CancellationToken ct = default);
    }
}