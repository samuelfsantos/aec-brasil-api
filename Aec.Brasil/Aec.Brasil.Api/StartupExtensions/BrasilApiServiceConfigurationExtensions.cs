using Microsoft.Extensions.Options;
using Aec.Brasil.Services.Configurations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Aec.Brasil.Api.Configurations
{
    public static class BrasilApiServiceConfigurationExtensions
    {
        public static void AddBrasilApiServiceConfig(this IServiceCollection services, IConfiguration configuration)
        {
            var _configurations = new BrasilApiServiceConfiguration();
            new ConfigureFromConfigurationOptions<BrasilApiServiceConfiguration>(configuration.GetSection("BrasilApiServiceConfiguration")).Configure(_configurations);

            services.AddSingleton(_configurations);
        }
    }
}
