using System.Linq.Expressions;
using UzTexGroupV2.Domain.Entities;
using UzTexGroupV2.Infrastructure.DbContexts;

namespace UzTexGroupV2.Infrastructure.Repositories;

public class LocalizedRepositoryBase<T> : RepositoryBase<T> where T : LocalizedObject
{
    public Language Language { get; set; }

    public LocalizedRepositoryBase(UzTexGroupDbContext context) : base(context)
    {
    }

    public override async ValueTask<IQueryable<T>> GetAllAsync()
    {
        return (await base.GetAllAsync())
            .Where(entity => entity.LanguageCode == Language.Code);
    }

    public override async ValueTask<IQueryable<T>> GetByExpression(
        Expression<Func<T, bool>> expression,
        string[] includes)
    {
        return (await base
                .GetByExpression(expression, includes))
            .Where(entity => entity.LanguageCode == Language.Code);
    }

    public override async ValueTask<T> CreateAsync(T entity)
    {
        entity.LanguageCode = this.Language.Code;
        return await base.CreateAsync(entity);
    }

    public override async ValueTask<T> UpdateAsync(T entity)
    {
        entity.LanguageCode = this.Language.Code;
        return await base.UpdateAsync(entity);
    }

    public override async ValueTask<T> DeleteAsync(T entity)
    {
        entity.LanguageCode = this.Language.Code;
        return await base.DeleteAsync(entity);
    }
}