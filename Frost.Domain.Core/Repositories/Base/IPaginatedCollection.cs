namespace Frost.Domain.Core.Repositories.Base;

public interface IPaginatedCollection<out TEntity>
{
    public int PageSize { get; }

    public int PageNumber { get; }

    public IReadOnlyList<TEntity> Collection { get; }
}