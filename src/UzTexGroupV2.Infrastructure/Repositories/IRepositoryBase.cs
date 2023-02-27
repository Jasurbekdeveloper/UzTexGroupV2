using System.Linq.Expressions;
using UzTexGroupV2.Domain.Entities;

namespace UzTexGroupV2.Infrastructure.Repositories;

public interface IRepositoryBase<T> where T : class
{
    ValueTask<IQueryable<T>> GetAllAsync();
    ValueTask<IQueryable<T>> GetByExpression(
        Expression<Func<T, bool>> expression,
        string[] includes);
    ValueTask<T> CreateAsync(T entity);
    ValueTask<T> UpdateAsync(T entity);
    ValueTask<T> DeleteAsync(T entity);
}