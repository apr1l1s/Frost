using Frost.Domain.Core.Entity.Base;

namespace Frost.Domain.Core.Entity.Products;

public class Product : BaseGuidEntity, IAuditedEntity
{
    public ProductName Name { get; private set; }

    public Barcode? Barcode { get; private set; }

    public Category Category { get; private set; }
    public Guid CategoryId { get; private set; }

    public ExpirationDate ExpirationDate { get; private set; }

    public ProductQuantity Quantity { get; private set; }

    public UnitType Unit { get; private set; }

    public Guid StorageLocationId { get; private set; }

    public DateTime CreationDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public DateTime? DeletionDate { get; set; }

    private Product()
    {
    }

    public static Product Create(
        ProductName name,
        Category category,
        ExpirationDate expirationDate,
        ProductQuantity quantity,
        UnitType unit,
        Guid storageLocationId,
        Barcode? barcode = null)
    {
        // Здесь вся валидация в одном месте
        if (category is null)
            throw new ArgumentNullException(nameof(category));

        if (storageLocationId == Guid.Empty)
        {
            throw new ArgumentException("StorageLocationId обязателен", nameof(storageLocationId));
        }

        if (quantity.Value <= 0)
        {
            throw new ArgumentException("Количество должно быть больше нуля", nameof(quantity));
        }

        // Можно добавить дополнительные бизнес-правила
        if (expirationDate.IsExpired())
        {
            throw new ArgumentException("Нельзя добавить просроченный продукт");
        }

        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = name,
            Barcode = barcode,
            Category = category,
            CategoryId = category.Id,
            ExpirationDate = expirationDate,
            Quantity = quantity,
            Unit = unit,
            StorageLocationId = storageLocationId
        };

        return product;
    }

    public static Product Create(string title, DateTime expirationDate)
    {
        return new Product
        {
            Name = ProductName.Create(title),
            ExpirationDate = ExpirationDate.FromDateTime(expirationDate)
        };
    }

    public bool IsExpired() => ExpirationDate.IsExpired();

    public bool IsExpiringSoon(int daysThreshold = 3) => ExpirationDate.IsExpiringSoon(daysThreshold);

    public void ReduceQuantity(ProductQuantity amount)
    {
        if (amount.Value > Quantity.Value)
            throw new InvalidOperationException("Нельзя списать больше, чем есть");

        Quantity = Quantity.Subtract(amount);
        ModifiedDate = DateTime.UtcNow;
    }

    public void IncreaseQuantity(ProductQuantity amount)
    {
        Quantity = Quantity.Add(amount);
        ModifiedDate = DateTime.UtcNow;
    }

    public void UpdateExpirationDate(ExpirationDate newDate)
    {
        ExpirationDate = newDate;
        ModifiedDate = DateTime.UtcNow;
    }

    public void ChangeStorageLocation(Guid newStorageLocationId)
    {
        StorageLocationId = newStorageLocationId;
        ModifiedDate = DateTime.UtcNow;
    }

    public void UpdateBarcode(Barcode? newBarcode)
    {
        Barcode = newBarcode;
        ModifiedDate = DateTime.UtcNow;
    }
}