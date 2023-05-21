using Autofac;
using GamesPlatform.Infrastructure.AutoMappers;
using Microsoft.Extensions.Configuration;

namespace GamesPlatform.Infrastructure.IoC
{
    public class ContainerModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterInstance(AutoMapperConfig.Initialize()).SingleInstance();
            builder.Build();
        }
    }
}
