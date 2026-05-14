namespace Frost.Domain.Core.Entities.Products;

public record ProductName(string Value)
{
    public static implicit operator ProductName(string value) => new(value);
    public static implicit operator string(ProductName name) => name.Value;

    public static ProductName Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length > 100)
        {
            throw new ArgumentException("Invalid product name");
        }

        return new ProductName(value.Trim());
    }
}