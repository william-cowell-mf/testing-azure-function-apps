using System;

namespace FunctionApp.Services
{
    internal sealed class QueueService : IQueueService
    {
        void IQueueService.DoSomethingWithQueueMessage(string message)
        {
            Console.WriteLine("Received message from queue: {0}", message);
        }
    }
}