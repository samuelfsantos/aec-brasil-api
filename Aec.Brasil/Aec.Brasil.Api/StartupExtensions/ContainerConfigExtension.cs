
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Aec.Brasil.IoC;

namespace Aec.Brasil.Api.StartupExtensions
{
    public static class ContainerConfigExtension
    {
        public static void ConfigureContainer(this WebApplicationBuilder builder)
        {
            builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
            {
                builder.RegisterModule(new ApplicationModule());
                builder.RegisterModule(new MediatorModule());
            });
        }
    }
}
