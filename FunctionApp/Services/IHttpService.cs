namespace FunctionApp.Services
{
    public interface IHttpService
    {
        string GetResponse(string name, string requestBody);
    }
}