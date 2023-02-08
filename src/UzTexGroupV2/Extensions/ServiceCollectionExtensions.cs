using Microsoft.EntityFrameworkCore;
using UzTexGroupV2.Filters;
using UzTexGroupV2.Infrastructure.DbContexts;
using UzTexGroupV2.Infrastructure.Repositories;

namespace UzTexGroupV2.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDbContexts(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContextPool<UzTexGroupDbContext>(obj =>
        {
            obj.UseSqlServer(configuration.GetConnectionString("DefaultConnectionString"),
                obj => obj.EnableRetryOnFailure());
        });

        return services;
    }

    public static IServiceCollection ConfigureRepositories(this IServiceCollection serviceCollection)
    {
        //DO-NOT: Unit Of works can't to add to services as Transient
        serviceCollection.AddScoped<LocalizedUnitOfWork>();
        serviceCollection.AddScoped<UnitOfWork>();
        
        return serviceCollection;
    }
}
