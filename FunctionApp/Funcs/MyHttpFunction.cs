using System.IO;
using System.Threading.Tasks;
using FunctionApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace FunctionApp.Funcs
{
    public sealed class MyHttpFunction
    {
        private readonly IHttpService _service;

        public MyHttpFunction(IHttpService service)
        {
            _service = service;    
        }

        [FunctionName("MyHttpFunction")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var name = req.Query["name"];
            var requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            return new OkObjectResult(this._service.GetResponse(name, requestBody));
        }
    }
}
