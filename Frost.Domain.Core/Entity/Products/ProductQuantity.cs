namespace Frost.Domain.Core.Entity.Products;

public record ProductQuantity(decimal Value)
{
    public static ProductQuantity Zero => new(0);

    public ProductQuantity Add(ProductQuantity other) => new(Value + other.Value);

    public ProductQuantity Subtract(ProductQuantity other) => new(Value - other.Value);

    public bool IsLowStock(decimal threshold = 1) => Value <= threshold;
}