using System;

namespace FunctionApp.Services
{
    internal sealed class QueueService : IQueueService
    {
        void IQueueService.DoSomethingWithQueueMessage(string message)
        {
            Console.WriteLine("Queue received: {0}", message);
        }
    }
}