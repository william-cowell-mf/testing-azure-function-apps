using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace FunctionApp.Tests
{
    public sealed class ConfigurationTests
    {
        public readonly static IEnumerable<object[]> _testCases = typeof(Configuration)
                .Assembly
                .GetTypes()
                .Where(ContainsAzureFunction)
                .Select(type => new [] {type})
                .ToArray();

        private static bool ContainsAzureFunction(Type type)
            => type.GetMethods().Any(method => method.GetCustomAttributes(typeof(FunctionNameAttribute), true).Length > 0);

        [Theory]
        [MemberData(nameof(_testCases))]
        public void Configure_ConfiguresDependenciesFor_AllAzureFunctions(Type azureFunctionType)
        {
            var services = new ServiceCollection();
            Configuration.Apply(services);

            var provider = services.BuildServiceProvider();
            var function = provider.GetService(azureFunctionType);
            
            function
                .Should()
                .NotBeNull(
                    because: $"Cannot initialise an instance of '{azureFunctionType}'");
        }
    }
}