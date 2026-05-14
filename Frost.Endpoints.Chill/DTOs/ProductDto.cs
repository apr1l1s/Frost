using Frost.Domain.Core.Entities.Products;

namespace Frost.Endpoints.Chill.DTOs;

public record ProductDto(Guid Id,
    string Name,
    string Barcode,
    Category Category,
    DateOnly ExpirationDate,
    decimal Quantity,
    UnitType Unit,
    Guid StorageLocationId);