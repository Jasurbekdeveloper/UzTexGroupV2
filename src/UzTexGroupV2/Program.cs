using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.FileProviders;
using UzTexGroupV2.Extensions;
using UzTexGroupV2.MIddlewares;

namespace UzTexGroupV2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Directory.Exists(Directory.GetCurrentDirectory() + "/wwwroot"));
            var builder = WebApplication.CreateBuilder(args);

            builder.Services
                .AddDbContexts(builder.Configuration)
                .ConfigureRepositories()
                .AddMiddlewares()
                .AddApplication()
                .AutentificationService(builder.Configuration);

            builder.AdSeridLogg(builder.Configuration);

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();


            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();
            app.UseCors(policyBuilder =>
            {
                policyBuilder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
            app.UseMiddleware<GlobalExceptionHandlingMiddleware>();
            app.UseStaticFiles(new StaticFileOptions()
            {
                HttpsCompression = HttpsCompressionMode.Compress
            });
            app.UseMiddleware<LocalizationTrackerMiddleware>();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute("default",
                "/{langCode=uz}/{controller=User}/{action=Index}",
                defaults: new { langCode = "uz" });

            app.Run();
        }
    }
}