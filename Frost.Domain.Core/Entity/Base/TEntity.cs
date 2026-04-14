namespace Frost.Domain.Core.Entity.Base;

public class TEntity<TId>
{
    public TId? Id { get; protected set; }
}