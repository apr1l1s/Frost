namespace Frost.Domain.Core.Entity.Products;

public record ExpirationDate(DateOnly Value)
{
    public bool IsExpired() => Value < DateOnly.FromDateTime(DateTime.UtcNow);

    public bool IsExpiringSoon(int days = 3) => Value <= DateOnly.FromDateTime(DateTime.UtcNow.AddDays(days));

    public static ExpirationDate FromDateTime(DateTime date) => new(DateOnly.FromDateTime(date));
}