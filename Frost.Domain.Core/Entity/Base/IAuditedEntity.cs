namespace Frost.Domain.Core.Entity.Base;

public interface IAuditedEntity
{
    public DateTime CreationDate { get; protected set; }

    public DateTime? ModifiedDate { get; protected set; }

    public DateTime? DeletionDate { get; protected set; }

    public bool IsDeleted => DeletionDate != null;

}