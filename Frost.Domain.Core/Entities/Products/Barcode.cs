namespace Frost.Domain.Core.Entities.Products;

public record Barcode(string Value)
{
    public static implicit operator Barcode(string value) => new(value);
    public static implicit operator string(Barcode name) => name.Value;
    
    public static Barcode Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Barcode cannot be empty");
        }

        // Можно добавить валидацию EAN-13, EAN-8 и т.д.
        return new Barcode(value.Trim());
    }
}