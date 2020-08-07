using System;
using System.Linq;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;

namespace FunctionApp.Tests.Helpers
{
    public class AzureFunctionBuilder
    {
        private readonly ServiceCollection _services = new ServiceCollection();

        public AzureFunctionBuilder()
        {
            Configuration.Apply(_services);    
        }

        public AzureFunctionBuilder Use<TDependency>(TDependency instance) where TDependency : class
        {
            var registration = _services.FirstOrDefault(descriptor => descriptor.ServiceType == typeof(TDependency));
            
            if (registration != null)
                _services.Remove(registration);
            
            _services.AddSingleton<TDependency>(instance);

            return this;
        }

        public TService Build<TService>() where TService : class
        {
            return Build(typeof(TService)).As<TService>();
        }

        public object Build(Type type)
        {
            var provider = _services.BuildServiceProvider();

            return provider.GetService(type);
        }
    }
}