using Cardano.Core.Json.Implementations;
using Cardano.Core.Json.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Cardano.Core.Json
{
    public static class JsonServices
    {
        public static IServiceCollection AddJsonServices(this IServiceCollection services)
        {
            services.AddTransient<IJsonSerializer, JsonSerializer>();

            return services;
        }
    }
}
