using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Text;
using UzTexGroupV2.Application.Services;
using UzTexGroupV2.Domain.Enums;
using UzTexGroupV2.Infrastructure.Authentication;
using UzTexGroupV2.Infrastructure.DbContexts;
using UzTexGroupV2.Infrastructure.Repositories;
using UzTexGroupV2.MIddlewares;

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

        services.Configure<JwtOptions>(configuration.GetSection("JwtSettings"));

        services.AddSwaggerService();
        return services;
    }

    public static IServiceCollection ConfigureRepositories(this IServiceCollection serviceCollection)
    {
        //DO-NOT: Unit Of works can't to add to services as Transient
        serviceCollection.AddScoped<LocalizedUnitOfWork>();
        serviceCollection.AddScoped<UnitOfWork>();
        serviceCollection.AddTransient<IGenerateToken, GenerateToken>();
        serviceCollection.AddSingleton<IPasswordHasher, PasswordHasher>();
        return serviceCollection;
    }

    public static IServiceCollection AddApplication(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<AddressService>();
        serviceCollection.AddScoped<ApplicationService>();
        serviceCollection.AddScoped<CompanyService>();
        serviceCollection.AddScoped<FactoryService>();
        serviceCollection.AddScoped<JobService>();
        serviceCollection.AddScoped<NewsService>();
        serviceCollection.AddScoped<UserService>();

        serviceCollection.AddHttpContextAccessor();

        serviceCollection.AddScoped<IAuthenticationService, AuthenticationService>();
        return serviceCollection;
    }

    public static IServiceCollection AddMiddlewares(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<LocalizationTrackerMiddleware>();

        return serviceCollection;
    }

    public static WebApplicationBuilder AdSeridLogg(
           this WebApplicationBuilder builder,
           IConfiguration configuration)
    {
        var logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .Enrich.FromLogContext()
            .CreateLogger();

        builder.Logging.ClearProviders();
        builder.Logging.AddSerilog(logger);

        return builder;
    }
    public static IServiceCollection AutentificationService(
            this IServiceCollection services,
            IConfiguration configuration)
    {
        services.AddAuthorization(options =>
        {
            options.AddPolicy("UserPolicy", options =>
            {
                options.RequireRole(Role.Admin.ToString(), Role.SuperAdmin.ToString());
            });
        });

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration["JwtSettings:Issuer"],
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(configuration["JwtSettings:SecretKey"])),
                ClockSkew = TimeSpan.Zero
            };
        });

        return services;
    }
    private static void AddSwaggerService(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "UzTexGroup.Api", Version = "v1" });

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Description =
                    "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                }
            });
        });
    }
}