namespace Frost.Domain.Core.Entities.Products;

public class Category
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string? Description { get; private set; }

    private Category() { }

    public Category(string name, string? description = null)
    {
        Id = Guid.NewGuid();
        Name = name.Trim();
        Description = description?.Trim();
    }
}