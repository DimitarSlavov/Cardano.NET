using Cardano.Core.Http;
using Cardano.Core.Json;
using Cardano.Explorer.Rest.Api.Implementation;
using Cardano.Explorer.Rest.Api.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Cardano.Explorer.Rest.Api
{
    public static class CardanoExplorerServices
    {
        private static Uri DefaultUrl => new Uri("http://localhost:8100/");

        public static IServiceCollection AddExplorerServices(this IServiceCollection services, Uri nodeUrl = default)
        {
            services.AddJsonServices();
            services.AddHttpServices(HttpHelper.CardanoExplorerHttpClient, nodeUrl ?? DefaultUrl);

            services.AddSingleton<IAddressesRequests, AddressesRequests>();
            services.AddSingleton<IBlocksRequests, BlocksRequests>();
            services.AddSingleton<IEpochsRequests, EpochsRequests>();
            services.AddSingleton<IGenesisRequests, GenesisRequests>();
            services.AddSingleton<IHttpBridgeRequests, HttpBridgeRequests>();
            services.AddSingleton<ITransactionsRequests, TransactionsRequests>();

            return services;
        }
    }
}
