using Cardano.Wallet.Rest.Api.Interfaces.Miscellaneous;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Cardano.Wallet.Rest.Api.Tests.Miscellaneous
{
    internal class NetworkRequestsTests : MiscellaneousRequestsTestsBase
    {
        [Test]
        public async Task TestGetClockAsync()
        {
            var result = await GetCardanoWalletService<INetworkRequests>()
                .GetClockAsync();

            AssertOK(result.CardanoHttpResponseModel);
        }

        [Test]
        public async Task TestGetInformationAsync()
        {
            var result = await GetCardanoWalletService<INetworkRequests>()
                .GetInformationAsync();

            AssertOK(result.CardanoHttpResponseModel);
        }

        [Test]
        public async Task TestGetParametersAsync()
        {
            var result = await GetCardanoWalletService<INetworkRequests>()
                .GetParametersAsync();

            AssertOK(result.CardanoHttpResponseModel);
        }
    }
}