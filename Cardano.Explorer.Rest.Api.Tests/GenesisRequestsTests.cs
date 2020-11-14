using Cardano.Core.Nomenclatures;
using Cardano.Explorer.Rest.Api.Interfaces;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Cardano.Explorer.Rest.Api.Tests
{
    internal class GenesisRequestsTests : CardanoCardanoExplorerRestApiTestsBase
    {
        [Test]
        public async Task TestGetSummaryAsync()
        {
            var result = await GetExplorerService<IGenesisRequests>()
                .GetSummaryAsync();

            AssertOK(result.CardanoHttpResponseModel);
        }

        [Test]
        public async Task TestGetTotalPagesAsync()
        {
            var result = await GetExplorerService<IGenesisRequests>()
                .GetTotalPagesAsync(1, FilterEnum.NotRedeemed);

            AssertOK(result.CardanoHttpResponseModel);
        }

        [Test]
        public async Task TestGetAddressInfoAsync()
        {
            var result = await GetExplorerService<IGenesisRequests>()
                .GetAddressInfoAsync(1, 10, FilterEnum.NotRedeemed);

            AssertOK(result.CardanoHttpResponseModel);
        }

        [Test]
        public async Task TestGetTotalAdaSupplyAsync()
        {
            var result = await GetExplorerService<IGenesisRequests>()
                .GetTotalAdaSupplyAsync();

            AssertOK(result.CardanoHttpResponseModel);
        }
    }
}
