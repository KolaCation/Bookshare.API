using System.Linq.Expressions;

namespace Bookshare.Domain.ValidationRules
{
    public interface IGenericRules<T> : IValidationRule where T : class
    {
        Task<bool> NotAnyAsyncDbContext(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken);
        Task<bool> AnyAsyncDbContext(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken);
    }
}
