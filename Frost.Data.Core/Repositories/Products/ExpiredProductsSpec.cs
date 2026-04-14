using Frost.Data.Core.Repositories.Base;
using Frost.Domain.Core.Entity.Products;

namespace Frost.Data.Core.Repositories;

public class ExpiredProductsSpec : BaseSpecification<Product>
{
    public ExpiredProductsSpec()
    {
        // Главное условие
        AddCriteria(p => p.ExpirationDate.IsExpired());

        // Подгружаем категорию, чтобы потом в ответе было название категории
        AddInclude(p => p.Category);

        // Сортируем по дате просрочки (самые просроченные сверху)
        ApplyOrderBy(p => p.ExpirationDate.Value);
    }
}