using Cardano.Explorer.Rest.Api.Models;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Cardano.Core.Nomenclatures;
using Cardano.Explorer.Rest.Api.Common;
using Cardano.Explorer.Rest.Api.Interfaces;
using Cardano.Core.Models.Common;
using Cardano.Core.Http;
using Cardano.Core.Http.Requests.Interfaces;

namespace Cardano.Explorer.Rest.Api.Implementation
{
    internal class GenesisRequests : IGenesisRequests
    {
        private readonly IGetRequests getRequests;

        public GenesisRequests(IGetRequests getRequests)
        {
            this.getRequests = getRequests;
        }

        public async Task<Response<Right<GenesisBlock>>> GetSummaryAsync()
        {
            var path = HttpHelper.UrlCombine(
                PathConstants.Api,
                PathConstants.Genesis,
                PathConstants.Summary);

            return await getRequests.GetAsync<Right<GenesisBlock>>(path);
        }

        public async Task<Response<Right<ulong>>> GetTotalPagesAsync(
            uint pageSize,
            FilterEnum filter)
        {
            var path = new StringBuilder(HttpHelper.UrlCombine(
                PathConstants.Api,
                PathConstants.Genesis,
                PathConstants.Address,
                PathConstants.Pages,
                PathConstants.Total));

            var queryParams = new Dictionary<string, object>();
            queryParams.Add(nameof(pageSize), pageSize);
            queryParams.Add(nameof(filter), filter.GetValue());

            path.Append(queryParams.ToQueryString());

            return await getRequests.GetAsync<Right<ulong>>(path.ToString());
        }

        public async Task<Response<Right<IEnumerable<GenesisAddress>>>> GetAddressInfoAsync(
            uint page,
            uint pageSize,
            FilterEnum filter)
        {
            var path = new StringBuilder(HttpHelper.UrlCombine(
                PathConstants.Api,
                PathConstants.Genesis,
                PathConstants.Address));

            var queryParams = new Dictionary<string, object>();
            queryParams.Add(nameof(page), page);
            queryParams.Add(nameof(pageSize), pageSize);
            queryParams.Add(nameof(filter), filter.GetValue());

            path.Append(queryParams.ToQueryString());

            return await getRequests.GetAsync<Right<IEnumerable<GenesisAddress>>>(path.ToString());
        }

        public async Task<Response<Right<decimal>>> GetTotalAdaSupplyAsync()
        {
            var path = HttpHelper.UrlCombine(
                PathConstants.Api,
                PathConstants.Supply,
                PathConstants.Ada);

            return await getRequests.GetAsync<Right<decimal>>(path);
        }
    }
}
