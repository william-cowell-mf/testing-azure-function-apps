using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace FunctionApp.Tests.Helpers
{
    public class AzureFunctionBuilder
    {
        private readonly ServiceCollection _services;

        public AzureFunctionBuilder()
        {
            _services = new ServiceCollection();
            Configuration.Apply(_services);    
        }

        public AzureFunctionBuilder Use<TDependency>(TDependency instance) where TDependency : class
        {
            var registration = _services.First(descriptor => descriptor.ServiceType == typeof(TDependency));
            
            _services.Remove(registration);
            _services.AddSingleton<TDependency>(instance);

            return this;
        }

        public TService Build<TService>() where TService : class
        {
            return (TService)Build(typeof(TService));
        }

        public object Build(Type type)
        {
            var provider = _services.BuildServiceProvider();

            return provider.GetService(type);
        }
    }
}