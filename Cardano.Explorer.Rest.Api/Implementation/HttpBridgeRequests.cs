using Cardano.Explorer.Rest.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cardano.Core.Nomenclatures;
using Cardano.Explorer.Rest.Api.Common;
using Cardano.Explorer.Rest.Api.Interfaces;
using Cardano.Core.Models.Common;
using Cardano.Core.Http;
using Cardano.Core.Http.Requests.Interfaces;

namespace Cardano.Explorer.Rest.Api.Implementation
{
    internal class HttpBridgeRequests : IHttpBridgeRequests
    {
        private readonly IGetRequests getRequests;

        public HttpBridgeRequests(IGetRequests getRequests)
        {
            this.getRequests = getRequests;
        }

        public async Task<Response<IEnumerable<AddressBalance>>> GetAddressBalanceAsync(
            NetworkEnum network,
            string address)
        {
            var path = HttpHelper.UrlCombine(
                network.GetValue(),
                PathConstants.Utxos,
                address);

            return await getRequests.GetAsync<IEnumerable<AddressBalance>>(path);
        }
    }
}
