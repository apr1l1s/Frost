using System.Linq.Expressions;

namespace Frost.Domain.Core.Repositories.Base;

public interface ISpecification<T>
{
    /// <summary>
    /// Основное условие фильтрации (Where)
    /// </summary>
    Expression<Func<T, bool>> Criteria { get; }

    /// <summary>
    /// Список Include'ов (подгрузка связанных сущностей)
    /// </summary>
    List<Expression<Func<T, object>>> Includes { get; }

    /// <summary>
    /// Сортировка (OrderBy)
    /// </summary>
    Expression<Func<T, object>>? OrderBy { get; }

    /// <summary>
    /// Использовать AsNoTracking (по умолчанию true)
    /// </summary>
    bool AsNoTracking { get; }
}