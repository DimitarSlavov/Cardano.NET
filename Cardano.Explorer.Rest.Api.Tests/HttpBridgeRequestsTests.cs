using Cardano.Core.Nomenclatures;
using Cardano.Explorer.Rest.Api.Interfaces;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Cardano.Explorer.Rest.Api.Tests
{
    internal class HttpBridgeRequestsTests : CardanoCardanoExplorerRestApiTestsBase
    {
        [Test]
        public async Task TestGetAddressBalanceAsync()
        {
            var result = await GetExplorerService<IHttpBridgeRequests>()
                .GetAddressBalanceAsync(
                NetworkEnum.Testnet,
                "2cWKMJemoBahqsqXZMytAazDJVZzxbWrfyrokQrNNyqb1XrNefsWHF2yRxSf9zx4F1cgB");

            AssertOK(result.CardanoHttpResponseModel);
        }
    }
}
