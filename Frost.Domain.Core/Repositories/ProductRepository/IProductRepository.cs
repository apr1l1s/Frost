using Frost.Domain.Core.Entities.Products;
using Frost.Domain.Core.Repositories.Base;

namespace Frost.Domain.Core.Repositories.ProductRepository;

public interface IProductRepository
    : IRepository<Product, Guid>
{
    Task<IReadOnlyList<Product>> GetExpiredAsync(CancellationToken ct = default);

    Task<IReadOnlyList<Product>> GetExpiringSoonAsync(int days = 3, CancellationToken ct = default);

    Task<IReadOnlyList<Product>> GetByStorageLocationAsync(Guid storageLocationId, CancellationToken ct = default);
}