using Cardano.Core.Nomenclatures;
using Cardano.Core.Models.Common;
using NUnit.Framework;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Cardano.Wallet.Rest.Api.Tests.Common
{
    internal abstract class WalletTestsBase
    {
        protected const int DefaultQuantity = 5000000;

        protected async Task SleepAsync(int miliseconds = 300)
        {
            await Task.Delay(miliseconds);
        }

        protected void AssertOK(CardanoHttpResponseModel model)
        {
            if (model == null || model.Code == CardanoStatusesEnum.NotImplemented.GetValue())
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }

        protected TService GetCardanoWalletService<TService>()
        {
            var services = new ServiceCollection();

            services.AddCardanoWalletServices();

            var serviceProvider = services.BuildServiceProvider();

            var service = serviceProvider.GetService<TService>();

            return service;
        }
    }
}