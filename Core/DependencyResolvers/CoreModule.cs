using Autofac;
using Autofac.Core;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Core.DependencyResolvers;

public class CoreModule : Module
{
    public void Load(IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<HttpContextAccessor, HttpContextAccessor>();
    }
}