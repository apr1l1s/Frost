namespace Frost.Domain.Core.Entities.Contracts;

public interface IAuditedEntity
{
    public DateTime DateCreated { get; set; }

    public DateTime? DateModified { get; set; }

    public DateTime? DateDeleted { get; set; }

    public bool IsDeleted => !DateDeleted.HasValue;
}