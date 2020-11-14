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
    internal class EpochsRequests : IEpochsRequests
    {
        private readonly IGetRequests getRequests;
        private readonly IJsonSerializer jsonSerializer;

        public EpochsRequests(IGetRequests getRequests,
            IJsonSerializer jsonSerializer)
        {
            this.getRequests = getRequests;
            this.jsonSerializer = jsonSerializer;
        }

        public async Task<Response<Right<BlockPage>>> GetEpochAsync(
            ulong epoch,
            uint page)
        {
            var path = new StringBuilder(HttpHelper.UrlCombine(
                PathConstants.Api,
                PathConstants.Epochs,
                epoch));

            var queryParams = new Dictionary<string, object>();
            queryParams.Add(nameof(page), page);

            path.Append(queryParams.ToQueryString());

            var response = await getRequests.GetAsync<Right<List<object>>>(path.ToString());
            var blockPage = new BlockPage(response.Content.Result, jsonSerializer);
            var result = response.Merge(blockPage);

            return result;
        }

        public async Task<Response<Right<IEnumerable<Block>>>> GetTotalPagesAsync(
            ulong epoch,
            ushort slot)
        {
            var path = HttpHelper.UrlCombine(
                PathConstants.Api,
                PathConstants.Epochs,
                epoch,
                slot);

            return await getRequests.GetAsync<Right<IEnumerable<Block>>>(path);
        }
    }
}
