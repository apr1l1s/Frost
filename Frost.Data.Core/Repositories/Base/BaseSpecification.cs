using System.Linq.Expressions;
using Frost.Domain.Core.Repositories.Base;

namespace Frost.Data.Core.Repositories.Base;

public abstract class BaseSpecification<T> : ISpecification<T>
{
    public Expression<Func<T, bool>> Criteria { get; private set; } = x => true;

    public List<Expression<Func<T, object>>> Includes { get; } = new();

    public Expression<Func<T, object>>? OrderBy { get; private set; }

    public bool AsNoTracking { get; private set; } = true;

    protected void AddCriteria(Expression<Func<T, bool>> criteria)
    {
        Criteria = criteria;
    }

    protected void AddInclude(Expression<Func<T, object>> includeExpression)
    {
        Includes.Add(includeExpression);
    }

    protected void ApplyOrderBy(Expression<Func<T, object>> orderByExpression)
    {
        OrderBy = orderByExpression;
    }

    protected void ApplyOrderByDescending(Expression<Func<T, object>> orderByDescExpression)
    {
        // Можно добавить, если понадобится сортировка по убыванию
        OrderBy = orderByDescExpression; // позже в репозитории обработаем
    }

    protected void ApplyAsNoTracking(bool asNoTracking = true)
    {
        AsNoTracking = asNoTracking;
    }
}