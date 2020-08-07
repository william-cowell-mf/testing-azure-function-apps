using System;
using FunctionApp.Services;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace FunctionApp.Funcs
{
    public sealed class MyQueueFunction
    {
        private readonly IQueueService _queueService;

        public MyQueueFunction(IQueueService queueService)
        {
            _queueService = queueService;    
        }

        [FunctionName("MyQueueFunction")]
        public void Run([QueueTrigger("myqueue-items", Connection = "")]string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
        }
    }
}
