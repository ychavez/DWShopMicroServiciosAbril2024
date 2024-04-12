using Microsoft.EntityFrameworkCore;
using Ordering.Domain.Common;
using Ordering.Infrastructure.Persistence;
using System.Linq.Expressions;

namespace Ordering.Infrastructure.Repositories
{
    public class GenericRepository<T>(OrderContext orderContext) where T : EntityBase
    {
        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate)
            => await orderContext
                                .Set<T>()
                                .Where(predicate)
                                .ToListAsync();

        public async Task<IReadOnlyList<T>> GetAsync(int offset, int limit,
            Expression<Func<T, bool>>? predicate, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy,
            params string[] includeString)
        {


        }
    }
}
