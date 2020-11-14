using Cardano.Core.Http;
using Cardano.Core.Json;
using Cardano.Wallet.Rest.Api.Implementation.ByronRandom;
using Cardano.Wallet.Rest.Api.Implementation.Miscellaneous;
using Cardano.Wallet.Rest.Api.Implementation.ShelleySequential;
using Cardano.Wallet.Rest.Api.Interfaces.ByronRandom;
using Cardano.Wallet.Rest.Api.Interfaces.Miscellaneous;
using Cardano.Wallet.Rest.Api.Interfaces.ShelleySequential;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Cardano.Wallet.Rest.Api
{
    public static class CardanoWalletServices
    {
        public static Uri DefaultUrl => new Uri("http://localhost:8090/v2/");

        public static IServiceCollection AddCardanoWalletServices(this IServiceCollection services, Uri nodeUrl = default)
        {
            services.AddJsonServices();
            services.AddHttpServices(HttpHelper.CardanoWalletHttpClient, nodeUrl ?? DefaultUrl);

            services.AddShelleyServices();
            services.AddByronServices();
            services.AddMiscellaneousServices();

            return services;
        }

        private static IServiceCollection AddByronServices(this IServiceCollection services)
        {
            services.AddSingleton<IByronWalletRequests, ByronWalletRequests>();
            services.AddSingleton<IByronAddressRequests, ByronAddressRequests>();
            services.AddSingleton<IByronCoinSelectionRequests, ByronCoinSelectionRequests>();
            services.AddSingleton<IByronMigrationRequests, ByronMigrationRequests>();
            services.AddSingleton<IByronTransactionRequests, ByronTransactionRequests>();

            return services;
        }

        private static IServiceCollection AddMiscellaneousServices(this IServiceCollection services)
        {
            services.AddSingleton<INetworkRequests, NetworkRequests>();
            //services.AddSingleton<IProxyRequests, ProxyRequests>();

            return services;
        }

        private static IServiceCollection AddShelleyServices(this IServiceCollection services)
        {
            services.AddSingleton<IWalletRequests, WalletRequests>();
            services.AddSingleton<IAddressRequests, AddressRequests>();
            services.AddSingleton<ICoinSelectionRequests, CoinSelectionRequests>();
            services.AddSingleton<IMigrationRequests, MigrationRequests>();
            services.AddSingleton<IStakePoolRequests, StakePoolRequests>();
            services.AddSingleton<ITransactionRequests, TransactionRequests>();

            return services;
        }
    }
}
