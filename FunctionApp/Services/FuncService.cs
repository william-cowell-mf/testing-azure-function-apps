using Newtonsoft.Json;

namespace MyFunctionApp.Services
{
    internal sealed class FuncService : IFuncService
    {
        string IFuncService.GetResponse(string name, string requestBody)
        {
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            return string.IsNullOrEmpty(name)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name}. This HTTP triggered function executed successfully.";
        }
    }
}