namespace Frost.Domain.Core.Entities.Products;

public record Quantity(decimal Value)
{
    public static implicit operator Quantity(decimal value) => new(value);
    public static implicit operator decimal(Quantity name) => name.Value;

    public static Quantity Zero => new(Value:0);

    public Quantity Add(Quantity other) => new(Value + other.Value);

    public Quantity Subtract(Quantity other) => new(Value - other.Value);

    public bool IsLowStock(decimal threshold = 1) => Value <= threshold;
}