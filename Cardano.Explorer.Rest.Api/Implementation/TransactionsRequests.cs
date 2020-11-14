using Cardano.Explorer.Rest.Api.Common;
using Cardano.Explorer.Rest.Api.Interfaces;
using Cardano.Explorer.Rest.Api.Models;
using Cardano.Core.Http;
using Cardano.Core.Models.Common;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Cardano.Core.Http.Requests.Interfaces;
using Cardano.Core.Json.Interfaces;

namespace Cardano.Explorer.Rest.Api.Implementation
{
    internal class TransactionsRequests : ITransactionsRequests
    {
        private readonly IGetRequests getRequests;
        private readonly IJsonSerializer jsonSerializer;

        public TransactionsRequests(IGetRequests getRequests,
            IJsonSerializer jsonSerializer)
        {
            this.getRequests = getRequests;
            this.jsonSerializer = jsonSerializer;
        }

        public async Task<Response<Right<IEnumerable<TransactionInformation>>>> GetTransactionsAsync()
        {
            var path = HttpHelper.UrlCombine(
                PathConstants.Api,
                PathConstants.Txs,
                PathConstants.Last);

            return await getRequests.GetAsync<Right<IEnumerable<TransactionInformation>>>(path);
        }

        public async Task<Response<Right<TransactionSummaryInformation>>> GetTransactionInformationSummaryAsync(
            string txId)
        {
            var path = HttpHelper.UrlCombine(
                PathConstants.Api,
                PathConstants.Txs,
                PathConstants.Summary,
                txId);

            return await getRequests.GetAsync<Right<TransactionSummaryInformation>>(path);
        }

        public async Task<Response<Right<TransactionStatsPage>>> GetTransactionsStatsAsync(
            uint page)
        {
            var path = new StringBuilder(HttpHelper.UrlCombine(
                PathConstants.Api,
                PathConstants.Stats,
                PathConstants.Txs));

            var queryParams = new Dictionary<string, object>();
            queryParams.Add(nameof(page), page);

            path.Append(queryParams.ToQueryString());

            var response = await getRequests.GetAsync<Right<List<object>>>(path.ToString());
            var transactionStatsPage = new TransactionStatsPage(response.Content.Result, jsonSerializer);
            var result = response.Merge(transactionStatsPage);

            return result;
        }
    }
}
