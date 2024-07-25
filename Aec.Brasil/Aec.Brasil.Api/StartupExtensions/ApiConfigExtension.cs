using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Aec.Brasil.Api.Configurations;
using System.Text.Json.Serialization;

namespace Aec.Brasil.Api.StartupExtensions
{
    public static class ApiConfigExtension
    {
        public static IServiceCollection AddApiConfig(this IServiceCollection services)
        {
            services.AddControllers();

            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
            });

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;

            });

            services.AddCors(p => p.AddPolicy("corsapp", builder =>
            {
                builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
            }));

            return services;
        }

        public static IApplicationBuilder UseApiConfig(this WebApplication app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseCors("Development");
            //    app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    app.UseCors("Development"); // Usar apenas nas demos => Configuração Ideal: Production
            //    app.UseHsts();
            //}

            app.UseCors("corsapp");

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            return app;
        }
    }
}
