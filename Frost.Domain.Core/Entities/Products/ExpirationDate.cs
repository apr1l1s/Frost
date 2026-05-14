namespace Frost.Domain.Core.Entities.Products;

public record ExpirationDate(DateOnly Value)
{
    public static implicit operator ExpirationDate(DateOnly value) => new(value);
    public static implicit operator DateOnly(ExpirationDate name) => name.Value;
    public bool IsExpired() => Value < DateOnly.FromDateTime(DateTime.UtcNow);

    public bool IsExpiringSoon(int days = 0) => Value <= DateOnly.FromDateTime(DateTime.UtcNow.AddDays(days));

    public static ExpirationDate FromDateTime(DateTime date) => new(DateOnly.FromDateTime(date));
}