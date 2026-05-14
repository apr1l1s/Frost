using System.Linq.Expressions;

namespace Frost.Domain.Core.Repositories.Base;

public interface ISpecification<T>
{
    Expression<Func<T, bool>> Criteria { get; }
    List<Expression<Func<T, object>>> Includes { get; }
    Expression<Func<T, object>>? OrderBy { get; }
    bool AsNoTracking { get; }
}