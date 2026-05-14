using Frost.Data.Core.DbContexts;
using Frost.Data.Core.Repositories;
using Frost.Domain.Core.Entities.Products;
using Frost.Domain.Core.Repositories.ProductRepository;
using Frost.Endpoints.Chill.DTOs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddDbContext<ChillDbContext>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// GET /products — получить все продукты
app.MapGet("/products", async (IProductRepository productRepository) =>
{
    // var products = await productRepository
    //     .GetPaginatedCollectionAsync(new object(), 1, 10);
    // return Results.Ok(products);
});

// GET /products/{id} — получить продукт по ID
app.MapGet("/products/{id:guid}", async (Guid id, IProductRepository productRepository) =>
{
    var product = await productRepository.GetNullableItemAsync(id).ConfigureAwait(false);
    return product is not null ? Results.Ok(product) : Results.NotFound();
});

// POST /products — создать новый продукт
app.MapPost("/products", async (ProductDto dto, IProductRepository productRepository) =>
{
    try
    {
        var created = new Product(dto.Name,
            dto.ExpirationDate,
            dto.Category.Id,
            dto.Quantity,
            dto.Unit,
            dto.StorageLocationId,
            dto.Barcode);

        await productRepository.AddAsync(created);

        return Results.Created($"/products/{created.Id}", created);
    }
    catch (Exception e)
    {
        return Results.BadRequest(e.Message);
    }
});

// PUT /products/{id} — обновить продукт
app.MapPut("/products/{id:guid}", async (Guid id, Product updatedProduct, IProductRepository productRepository) =>
{
    // if (string.IsNullOrWhiteSpace(updatedProduct.Name))
    // {
    //     return Results.BadRequest("Name is required.");
    // }
    //
    // if (true)
    // {
    //     return Results.NoContent();
    // }
    //
    // return Results.NotFound();
});

// DELETE /products/{id} — удалить продукт
app.MapDelete("/products/{id:guid}", (Guid id, IProductRepository productRepository) =>
{
    // if (productRepository.DeleteAsync(id))
    //     return Results.NoContent();
    // return Results.NotFound();
});

app.Run();