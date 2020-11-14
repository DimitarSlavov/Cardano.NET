using Cardano.Explorer.Rest.Api.Interfaces;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Cardano.Explorer.Rest.Api.Tests
{
    internal class EpochsRequestsTests : CardanoCardanoExplorerRestApiTestsBase
    {
        [Test]
        public async Task TestGetEpochAsync()
        {
            var result = await GetExplorerService<IEpochsRequests>()
                .GetEpochAsync(1, 1);

            AssertOK(result.CardanoHttpResponseModel);
        }

        [Test]
        public async Task TestGetTotalPagesAsync()
        {
            var result = await GetExplorerService<IEpochsRequests>()
                .GetTotalPagesAsync(1, 10);

            AssertOK(result.CardanoHttpResponseModel);
        }
    }
}
