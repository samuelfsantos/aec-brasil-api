using Autofac;
using Aec.Brasil.Tests.Interface;

namespace Aec.Brasil.Tests.Common
{
    public abstract class InitializeFixture<TDataContainer> where TDataContainer : IDataContainer, new()
    {
        protected IContainer container;

        public InitializeFixture()
        {

            var builder = new ContainerBuilder();

            builder.RegisterModule(new ApplicationModule());

            container = builder.Build();

            WorkingData = new TDataContainer();
        }

        protected TDataContainer WorkingData { get; }

        protected TEntity Resolve<TEntity>()
        {
            return container.Resolve<TEntity>();
        }
    }
}
