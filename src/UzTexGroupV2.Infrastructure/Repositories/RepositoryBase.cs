using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using UzTexGroupV2.Domain.Entities;
using UzTexGroupV2.Infrastructure.DbContexts;

namespace UzTexGroupV2.Infrastructure.Repositories;

public class RepositoryBase<T> : IRepositoryBase<T> where T : class 
{
    private readonly UzTexGroupDbContext context;
    public RepositoryBase(UzTexGroupDbContext context)
    {
        this.context = context;
    }
    
    public virtual async ValueTask<IQueryable<T>> GetAllAsync()
    {
        var a = context
            .Set<T>()
            .AsNoTracking();
        return a;
    }

    public virtual async ValueTask<IQueryable<T>> GetByExpression(
        Expression<Func<T, bool>> expression,
        string[] includes)
    {
        var entities = context
            .Set<T>()
            .Where(expression);


        foreach(var item in includes )
        {
            entities = entities.Include(item);
        }

        return entities;
    }

    public virtual async ValueTask<T> CreateAsync(T entity)
    {
        return (await context
                .Set<T>()
                .AddAsync(entity))
            .Entity;

    }

    public virtual async ValueTask<T> UpdateAsync(T entity)
    {
        return context
            .Set<T>()
            .Update(entity)
            .Entity;
    }

    public virtual async ValueTask<T> DeleteAsync(T entity)
    {
        return context
            .Set<T>()
            .Remove(entity)
            .Entity;
    }
}