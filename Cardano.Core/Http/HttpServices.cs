using Cardano.Core.Http.Requests.Implementations;
using Cardano.Core.Http.Requests.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Mime;

namespace Cardano.Core.Http
{
    public static class HttpServices
    {
        public static IServiceCollection AddHttpServices(this IServiceCollection services, string httpClientName, Uri nodeUrl)
        {
            services.AddHttpClient(httpClientName, e =>
            {
                e.BaseAddress = nodeUrl;
                e.DefaultRequestHeaders.Add(nameof(e.DefaultRequestHeaders.Accept), MediaTypeNames.Application.Json);
            });

            services.AddSingleton(new RequestsBase(httpClientName));
            services.AddSingleton<IGetRequests, GetRequests>();
            services.AddSingleton<IPostRequests, PostRequests>();
            services.AddSingleton<IPutRequests, PutRequests>();
            services.AddSingleton<IDeleteRequests, DeleteRequests>();

            return services;
        }
    }
}
