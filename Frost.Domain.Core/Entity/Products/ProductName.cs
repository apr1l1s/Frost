namespace Frost.Domain.Core.Entity.Products;

public record ProductName(string Value)
{
    public static ProductName Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length > 100)
        {
            throw new ArgumentException("Invalid product name");
        }

        return new ProductName(value.Trim());
    }
}