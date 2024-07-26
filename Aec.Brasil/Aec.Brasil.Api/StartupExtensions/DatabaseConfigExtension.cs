using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Aec.Brasil.Data;
using Microsoft.AspNetCore.Builder;
using System.Linq;

namespace Aec.Brasil.Api.StartupExtensions
{
    public static class DatabaseConfigExtension
    {
        public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AecBrasilContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
        }

        public static void ApplyMigrations(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var context = services.GetRequiredService<AecBrasilContext>();
                if (context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }
            }
        }
    }
}
