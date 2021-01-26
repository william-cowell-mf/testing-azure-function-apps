using FunctionApp.Funcs;
using FunctionApp.Services;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Xunit;

namespace FunctionApp.Tests.Unit
{
    public sealed class MyQueueFunctionTests
    {
        [Theory]
        [InlineData("input")]
        [InlineData("example")]
        [InlineData("hello world")]
        public void Run_InvokesQueueService_WithQueueMessage(string queueMessage)
        {
            var fakeService = Substitute.For<IQueueService>();
            var function = new MyQueueFunction(fakeService);

            function.Run(queueMessage, Substitute.For<ILogger>());

            fakeService
                .Received()
                .DoSomethingWithQueueMessage(queueMessage);
        }
    }
}