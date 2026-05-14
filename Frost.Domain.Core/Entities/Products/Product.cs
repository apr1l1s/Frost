using Frost.Domain.Core.Entities.Storage;

namespace Frost.Domain.Core.Entities.Products;

public class Product
{
    public Guid Id { get; private set; }

    public ProductName Name { get; private set; }
    public Barcode? Barcode { get; private set; }

    public Category Category { get; private set; }
    public Guid CategoryId { get; private set; }

    public ExpirationDate ExpirationDate { get; private set; }
    public Quantity Quantity { get; private set; }
    public UnitType Unit { get; private set; }

    public Guid StorageLocationId { get; private set; }

    public StorageLocation StorageLocation { get; private set; }

    public DateTime AddedAt { get; private set; }
    public DateTime? LastModifiedAt { get; private set; }

    private Product()
    {
    }

    public Product(ProductName name,
        ExpirationDate expirationDate,
        Guid categoryId,
        Quantity quantity,
        UnitType unit,
        Guid storageLocationId,
        Barcode? barcode = null)
    {
        Name = name;
        Barcode = barcode;
        CategoryId = categoryId;
        ExpirationDate = expirationDate;
        Quantity = quantity;
        Unit = unit;
        StorageLocationId = storageLocationId;
        AddedAt = DateTime.UtcNow;
    }

    public static Product Create(string name, DateOnly expirationDate, Guid categoryId, decimal quantity, UnitType unit,
        Guid storageLocationId, string barcode
    )
        => new(new ProductName(name), new ExpirationDate(expirationDate), categoryId, new Quantity(quantity), unit,
            storageLocationId, barcode);

    public bool IsExpired() => ExpirationDate.IsExpired();

    public bool IsExpiringSoon(int daysThreshold = 3) => ExpirationDate.IsExpiringSoon(daysThreshold);

    public void ReduceQuantity(Quantity amount)
    {
        if (amount.Value > Quantity.Value)
        {
            throw new InvalidOperationException("Нельзя списать больше, чем есть");
        }

        Quantity = Quantity.Subtract(amount);
        LastModifiedAt = DateTime.UtcNow;
    }

    public void IncreaseQuantity(Quantity amount)
    {
        Quantity = Quantity.Add(amount);
        LastModifiedAt = DateTime.UtcNow;
    }

    public void UpdateExpirationDate(ExpirationDate newDate)
    {
        ExpirationDate = newDate;
        LastModifiedAt = DateTime.UtcNow;
    }

    public void ChangeStorageLocation(Guid newStorageLocationId)
    {
        StorageLocationId = newStorageLocationId;
        LastModifiedAt = DateTime.UtcNow;
    }

    public void UpdateBarcode(Barcode? newBarcode)
    {
        Barcode = newBarcode;
        LastModifiedAt = DateTime.UtcNow;
    }
}