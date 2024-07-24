using Autofac;
using Microsoft.Extensions.Logging;
using Aec.Brasil.Data;
using Aec.Brasil.Data.Repositories;
using Aec.Brasil.Domain.Common;
using Aec.Brasil.Domain.Common.Notification;
using Aec.Brasil.Domain.Validators.Cidade;
using System.Reflection;

namespace Aec.Brasil.Tests.Common
{
    public class ApplicationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new MediatorModule());

            builder.RegisterModule(new AutoMapperModule());

            builder.Register<AecBrasilContext>(ctx => { return DatabaseContextInMemory.Create(); }).SingleInstance();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().SingleInstance();

            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>));

            builder.RegisterGeneric(typeof(Logger<>)).As(typeof(ILogger<>)).SingleInstance();

            builder.RegisterType<LoggerFactory>().As<ILoggerFactory>().SingleInstance();

			builder.RegisterAssemblyTypes(typeof(CidadeCriacaoValidator).GetTypeInfo().Assembly)
					   .Where(t => t.Name.EndsWith("Validator"))
					   .AsImplementedInterfaces();

			builder.RegisterAssemblyTypes(typeof(CidadeRepository).GetTypeInfo().Assembly)
					   .Where(t => t.Name.EndsWith("Repository"))
					   .AsImplementedInterfaces();

			builder.RegisterType<NotificationDomain>().As<INotificationDomain<NotificationDomainMessage>>().SingleInstance();
        }
    }
}
