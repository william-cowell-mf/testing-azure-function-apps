using FunctionApp.Funcs;
using FunctionApp.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FunctionApp
{
    public static class Configuration
    {
        public static void Apply(IServiceCollection services)
        {
            services.AddScoped<MyHttpFunction>();
            services.AddScoped<IHttpService, HttpService>();

            services.AddScoped<MyQueueFunction>();
            services.AddScoped<IQueueService, QueueService>();
        }
    }
}