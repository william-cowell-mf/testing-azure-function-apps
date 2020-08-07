namespace FunctionApp.Services
{
    public interface IFuncService
    {
        string GetResponse(string name, string requestBody);
    }
}