using Cardano.Explorer.Rest.Api.Interfaces;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Cardano.Explorer.Rest.Api.Tests
{
    internal class TransactionsRequestsTests : CardanoCardanoExplorerRestApiTestsBase
    {
        [Test]
        public async Task TestGetTransactionsAsync()
        {
            var result = await GetExplorerService<ITransactionsRequests>()
                .GetTransactionsAsync();

            AssertOK(result.CardanoHttpResponseModel);
        }

        [Test]
        public async Task TestGetTransactionInformationSummaryAsync()
        {
            var result = await GetExplorerService<ITransactionsRequests>()
                .GetTransactionInformationSummaryAsync(
                    "15d730e88f5d14a27ea06f4b6e355cd52c3394b896d4c8e57c6e973aee4eac28");

            AssertOK(result.CardanoHttpResponseModel);
        }
        [Test]
        public async Task TestGetTransactionsStatsAsync()
        {
            var result = await GetExplorerService<ITransactionsRequests>()
                .GetTransactionsStatsAsync(1);

            AssertOK(result.CardanoHttpResponseModel);
        }
    }
}
