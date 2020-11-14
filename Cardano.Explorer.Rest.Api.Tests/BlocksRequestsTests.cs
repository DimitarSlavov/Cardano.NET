using Cardano.Explorer.Rest.Api.Interfaces;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Cardano.Explorer.Rest.Api.Tests
{
    internal class BlocksRequestsTests : CardanoCardanoExplorerRestApiTestsBase
    {
        [Test]
        public async Task TestGetBlocksAsync()
        {
            var result = await GetExplorerService<IBlocksRequests>()
                .GetBlocksAsync(1, 1);

            AssertOK(result.CardanoHttpResponseModel);
        }

        [Test]
        public async Task TestGetTotalPagesAsync()
        {
            var result = await GetExplorerService<IBlocksRequests>()
                .GetTotalPagesAsync(1);

            AssertOK(result.CardanoHttpResponseModel);
        }

        [Test]
        public async Task TestGetBlockSummaryAsync()
        {
            var result = await GetExplorerService<IBlocksRequests>()
                .GetBlockSummaryAsync("b1122e2631dc9d436d519f34f4f43eab0df45eb77ed7b59cd24a7aafd873804d");

            AssertOK(result.CardanoHttpResponseModel);
        }

        [Test]
        public async Task TestGetTransactionsAsync()
        {
            var result = await GetExplorerService<IBlocksRequests>()
                .GetTransactionsAsync("b1122e2631dc9d436d519f34f4f43eab0df45eb77ed7b59cd24a7aafd873804d", 1, 1);

            AssertOK(result.CardanoHttpResponseModel);
        }
    }
}
