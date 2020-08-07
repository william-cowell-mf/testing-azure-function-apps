namespace FunctionApp.Services
{
    public interface IQueueService
    {
        void DoSomethingWithQueueMessage(string message);
    }
}