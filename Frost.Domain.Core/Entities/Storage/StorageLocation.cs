namespace Frost.Domain.Core.Entities.Storage;

public class StorageLocation
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } // "Холодильник на кухне", "Морозилка", "Балкон"
    public string? Description { get; private set; }
    public LocationType Type { get; private set; }

    private StorageLocation()
    {
    }

    public StorageLocation(string name, LocationType type, string? description = null)
    {
        Id = Guid.NewGuid();
        Name = name;
        Type = type;
        Description = description;
    }
}

public enum LocationType
{
    Refrigerator,

    Freezer,

    Pantry,

    Other
}