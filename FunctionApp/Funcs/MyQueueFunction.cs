using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace FunctionApp.Funcs
{
    public sealed class MyQueueFunction
    {
        public MyQueueFunction(string name)
        {
            Console.WriteLine("Constructing instance: {0}", name);
        }

        [FunctionName("MyQueueFunction")]
        public void Run([QueueTrigger("myqueue-items", Connection = "")]string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
        }
    }
}
