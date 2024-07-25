using Autofac;
using Aec.Brasil.Data;
using Aec.Brasil.Data.Repositories;
using Aec.Brasil.Domain.Common;
using Aec.Brasil.Domain.Common.Notification;
using Aec.Brasil.Domain.Validators.Cidade;
using System.Reflection;
using Aec.Brasil.Domain.Services;
using Autofac.Core;
using Aec.Brasil.Services.BrasilApi;

namespace Aec.Brasil.IoC
{
    public class ApplicationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(CidadeRepository).GetTypeInfo().Assembly)
                       .Where(t => t.Name.EndsWith("Repository"))
                       .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(typeof(CidadeCriacaoValidator).GetTypeInfo().Assembly)
                       .Where(t => t.Name.EndsWith("Validator"))
                       .AsImplementedInterfaces();

            builder.RegisterType<NotificationDomain>().As<INotificationDomain<NotificationDomainMessage>>().InstancePerLifetimeScope();

            builder.RegisterType<BrasilApiService>().As<IBrasilApiService>().InstancePerLifetimeScope();
        }
    }
}
