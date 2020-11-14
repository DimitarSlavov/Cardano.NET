using Cardano.Explorer.Rest.Api.Interfaces;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Cardano.Explorer.Rest.Api.Tests
{
    internal class AddressesRequestsTests : CardanoCardanoExplorerRestApiTestsBase
    {
        [Test]
        public async Task TestGetAddressSummaryAsync()
        {
            var result = await GetExplorerService<IAddressesRequests>()
                .GetAddressSummaryAsync("2cWKMJemoBahqsqXZMytAazDJVZzxbWrfyrokQrNNyqb1XrNefsWHF2yRxSf9zx4F1cgB");

            AssertOK(result.CardanoHttpResponseModel);
        }

        [Test]
        public async Task TestGetAddressAsync()
        {
            var result = await GetExplorerService<IAddressesRequests>()
                .GetAddressAsync(
                "7e9d46c0f822e2bf7e4662ac684fa2b283a1681521d8633c480917fa1d615e08",
                "2cWKMJemoBahqsqXZMytAazDJVZzxbWrfyrokQrNNyqb1XrNefsWHF2yRxSf9zx4F1cgB");

            AssertOK(result.CardanoHttpResponseModel);
        }
    }
}
