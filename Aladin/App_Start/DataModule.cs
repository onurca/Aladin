using Autofac;
using Framework;
using Framework.Context;
using Framework.Core.Logger;
using Framework.Service.Authentication;

namespace Aladin.App_Start
{
    internal class DataModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new Data.AladinContext()).As<IDataContext>().InstancePerRequest();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<Logger>().As<ILogger>().InstancePerLifetimeScope();
            builder.RegisterType<RoleService>().As<IRoleService>().InstancePerLifetimeScope();
            builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}