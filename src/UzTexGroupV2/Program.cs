using Swashbuckle.AspNetCore.SwaggerUI;
using UzTexGroupV2.Extensions;

namespace UzTexGroupV2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContexts(builder.Configuration);

            builder.Services.AddControllers();

            builder.Services.ConfigureRepositories();


            builder.Services.AddHttpContextAccessor();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();


            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllerRoute("default",
                "/{langCode=uz}/{controller=User}/{action=Index}",
                defaults: new { langCode = "uz" });

            app.Run();
        }
    }
}
