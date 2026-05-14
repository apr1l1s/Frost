namespace Frost.Domain.Core.Repositories.Base;

public interface IRepository<TEntity, in TKey>
{
    Task<TEntity> GetItemAsync(TKey id, CancellationToken ct = default);

    Task<TEntity?> GetNullableItemAsync(TKey id, CancellationToken ct = default);

    Task<TEntity?> GetNullableItemAsync(ISpecification<TEntity> specification, CancellationToken ct = default);

    Task<IReadOnlyList<TEntity>> GetCollectionAsync(IReadOnlyList<TKey> ids, CancellationToken ct = default);

    Task<IPaginatedCollection<TEntity>> GetPaginatedCollectionAsync(ISpecification<TEntity> specification,
        int pageNumber, int pageSize, CancellationToken ct = default);

    Task AddAsync(TEntity entity, CancellationToken ct = default);

    Task DeleteAsync(Guid id, CancellationToken ct = default);
}