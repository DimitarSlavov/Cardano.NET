using Cardano.Core.Http;
using Cardano.Core.Http.Requests.Interfaces;
using Cardano.Core.Json.Interfaces;
using Cardano.Core.Models.Common;
using Cardano.Explorer.Rest.Api.Common;
using Cardano.Explorer.Rest.Api.Interfaces;
using Cardano.Explorer.Rest.Api.Models;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cardano.Explorer.Rest.Api.Implementation
{
    internal class BlocksRequests : IBlocksRequests
    {
        private readonly IGetRequests getRequests;
        private readonly IJsonSerializer jsonSerializer;

        public BlocksRequests(IGetRequests getRequests,
            IJsonSerializer jsonSerializer)
        {
            this.getRequests = getRequests;
            this.jsonSerializer = jsonSerializer;
        }

        public async Task<Response<Right<BlockPage>>> GetBlocksAsync(
            uint page,
            uint pageSize)
        {
            var path = new StringBuilder(HttpHelper.UrlCombine(
                PathConstants.Api,
                PathConstants.Blocks,
                PathConstants.Pages));

            var queryParams = new Dictionary<string, object>();
            queryParams.Add(nameof(page), page);
            queryParams.Add(nameof(pageSize), pageSize);

            path.Append(queryParams.ToQueryString());

            var response = await getRequests.GetAsync<Right<List<object>>>(path.ToString());
            var blockPage = new BlockPage(response.Content.Result, jsonSerializer);
            var result = response.Merge(blockPage);

            return result;
        }

        public async Task<Response<Right<ulong>>> GetTotalPagesAsync(
            uint pageSize)
        {
            var path = new StringBuilder(HttpHelper.UrlCombine(
                PathConstants.Api,
                PathConstants.Blocks,
                PathConstants.Pages,
                PathConstants.Total));

            var queryParams = new Dictionary<string, object>();
            queryParams.Add(nameof(pageSize), pageSize);

            path.Append(queryParams.ToQueryString());

            return await getRequests.GetAsync<Right<ulong>>(path.ToString());
        }

        public async Task<Response<Right<BlockSummaryInformation>>> GetBlockSummaryAsync(
            string blockHash)
        {
            var path = HttpHelper.UrlCombine(
                PathConstants.Api,
                PathConstants.Blocks,
                PathConstants.Summary,
                blockHash);

            return await getRequests.GetAsync<Right<BlockSummaryInformation>>(path);
        }

        public async Task<Response<Right<IEnumerable<Transaction>>>> GetTransactionsAsync(
            string blockHash,
            ulong limit,
            ulong offset)
        {
            var path = new StringBuilder(HttpHelper.UrlCombine(
                PathConstants.Api,
                PathConstants.Blocks,
                PathConstants.Txs,
                blockHash));

            var queryParams = new Dictionary<string, object>();
            queryParams.Add(nameof(limit), limit);
            queryParams.Add(nameof(offset), offset);

            path.Append(queryParams.ToQueryString());

            return await getRequests.GetAsync<Right<IEnumerable<Transaction>>>(path.ToString());
        }
    }
}
