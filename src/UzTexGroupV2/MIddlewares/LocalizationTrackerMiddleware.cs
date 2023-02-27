using Microsoft.EntityFrameworkCore;
using UzTexGroupV2.Domain.Entities;
using UzTexGroupV2.Infrastructure.DbContexts;
using UzTexGroupV2.Infrastructure.Repositories;

namespace UzTexGroupV2.MIddlewares;

public class LocalizationTrackerMiddleware : IMiddleware
{
    private readonly LocalizedUnitOfWork _localizedUnitOfWork;
    private readonly UzTexGroupDbContext _uzTexGroupDbContext;

    public LocalizationTrackerMiddleware(LocalizedUnitOfWork localizedUnitOfWork,
        UzTexGroupDbContext uzTexGroupDbContext)
    {
        this._localizedUnitOfWork = localizedUnitOfWork;
        this._uzTexGroupDbContext = uzTexGroupDbContext;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var languageCode = context.Request.RouteValues["langCode"] as string;
        var storedLanguage = await GetStoredLanguage(languageCode) ?? await GetStoredDefaultLanguage();
        if (storedLanguage is not null)
            await this._localizedUnitOfWork
                .ChangeLocalization(storedLanguage);
        else 
            throw new Exception("Language not found");
        await next(context);
    }

    private async Task<Language?> GetStoredLanguage(string? languageCode)
    {
        return await this._uzTexGroupDbContext
            .Set<Language>()
            .FirstOrDefaultAsync(language => language.Code == languageCode);
    }
    private async Task<Language?> GetStoredDefaultLanguage()
    {
        return await this._uzTexGroupDbContext
            .Set<Language>()
            .FirstOrDefaultAsync();
    }
}