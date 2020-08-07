using System.Threading.Tasks;
using FluentAssertions;
using FunctionApp.Funcs;
using FunctionApp.Services;
using FunctionApp.Tests.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Xunit;

namespace FunctionApp.Tests.Funcs
{
    public sealed class MyHttpFunctionTests
    {
        [Fact]
        public async Task Run_ReturnsResponse_FromService()
        {
            var expectedResponseBody = "some response";
            var fakeService = Substitute.For<IFuncService>();
            fakeService
                .GetResponse(Arg.Any<string>(), Arg.Any<string>())
                .Returns(expectedResponseBody);

            var function = new AzureFunctionBuilder()
                .Use(fakeService)
                .Build<MyHttpFunction>();

            var response = await function.Run(CreateHttpRequest(), Substitute.For<ILogger>());
            var responseBody = response.As<OkObjectResult>().Value.ToString();

            responseBody
                .Should()
                .Be(expectedResponseBody);
        }

        private static HttpRequest CreateHttpRequest()
        {
            var context = new DefaultHttpContext();
            var request = context.Request;

            return request;
        }
    }
}