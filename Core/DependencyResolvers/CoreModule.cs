using Autofac;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Core.DependencyResolvers;

public class CoreModule : Module
{
    public void Load(ContainerBuilder builder)
    {
        builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>().SingleInstance();
    }
}