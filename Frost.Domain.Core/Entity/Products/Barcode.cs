namespace Frost.Domain.Core.Entity.Products;

public record Barcode(string Value)
{
    public static Barcode Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Barcode cannot be empty");

        // Можно добавить валидацию EAN-13, EAN-8 и т.д.
        return new Barcode(value.Trim());
    }
}