using Frost.Domain.Core.Entities.Contracts;

namespace Frost.Domain.Core.Entities.Base;

public class BaseEntity<TId> 
    : IAuditedEntity
{
    public TId Id { get; set; } = default!;

    public DateTime DateCreated { get; set; }

    public DateTime? DateModified { get; set; }

    public DateTime? DateDeleted { get; set; }
}