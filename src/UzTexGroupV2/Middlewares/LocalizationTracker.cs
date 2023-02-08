using Microsoft.EntityFrameworkCore;
using UzTexGroupV2.Domain.Entities;
using UzTexGroupV2.Infrastructure.DbContexts;
using UzTexGroupV2.Infrastructure.Repositories;

namespace UzTexGroupV2.Middlewares;

public class LocalizationTracker : IMiddleware
{
    private readonly LocalizedUnitOfWork _unitOfWork;
    private readonly UzTexGroupDbContext _dbContext;
    public LocalizationTracker(LocalizedUnitOfWork localizedUnitOfWork, UzTexGroupDbContext dbContext)
    {
        this._unitOfWork = localizedUnitOfWork;
        this._dbContext = dbContext;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var routeValues = context.Request.RouteValues;
        if (routeValues.ContainsKey("langCode"))
        {
            var language = await this.GetLanguageByCode(routeValues["langCode"] as string);
            await this._unitOfWork
                .ChangeLocalization(language);
        }

        await next(context);
    }

    private async Task<Language> GetLanguageByCode(string languageCode)
    {
        // var language = await this._dbContext
        //     .Set<Language>()
        //     .FirstOrDefaultAsync();
        //
        // language = (await this._dbContext
        //     .Set<Language>()
        //     .FirstOrDefaultAsync(language => language.Code == languageCode.ToLowerInvariant())) ?? language;

        // return language;
        return new Language()
        {
            Code = "uz",
            Name = "Uzbek"
        };
    }
}
