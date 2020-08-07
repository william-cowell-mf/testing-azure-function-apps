using FunctionApp.Funcs;
using FunctionApp.Services;
using FunctionApp.Tests.Helpers;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Xunit;

namespace FunctionApp.Tests.Integration
{
    public sealed class MyQueueFunctionTests
    {
        [Theory]
        [InlineData("input")]
        [InlineData("example")]
        [InlineData("hello world")]
        public void Run_InvokesQueueService_WithQueueMessage(string queueMessage)
        {
            var service = Substitute.For<IQueueService>();
            var function = new AzureFunctionBuilder()
                .Use(service)
                .Build<MyQueueFunction>();

            function.Run(queueMessage, Substitute.For<ILogger>());

            service
                .Received()
                .DoSomethingWithQueueMessage(queueMessage);
        }
    }
}