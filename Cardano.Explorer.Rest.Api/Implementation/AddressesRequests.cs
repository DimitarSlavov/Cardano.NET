using Cardano.Core.Http;
using Cardano.Core.Http.Requests.Interfaces;
using Cardano.Core.Models.Common;
using Cardano.Explorer.Rest.Api.Common;
using Cardano.Explorer.Rest.Api.Interfaces;
using Cardano.Explorer.Rest.Api.Models;
using System.Threading.Tasks;

namespace Cardano.Explorer.Rest.Api.Implementation
{
    internal class AddressesRequests : IAddressesRequests
    {
        private readonly IGetRequests getRequest;

        public AddressesRequests(IGetRequests getRequest)
        {
            this.getRequest = getRequest;
        }

        public async Task<Response<Right<Address>>> GetAddressSummaryAsync(
            string address)
        {
            var path = HttpHelper.UrlCombine(
                PathConstants.Api,
                PathConstants.Addresses,
                PathConstants.Summary,
                address);

            return await getRequest.GetAsync<Right<Address>>(path);
        }

        public async Task<Response<Right<Address>>> GetAddressAsync(
            string blockHash,
            string address)
        {
            var path = HttpHelper.UrlCombine(
                PathConstants.Api,
                PathConstants.Block,
                blockHash,
                PathConstants.Address,
                address);

            return await getRequest.GetAsync<Right<Address>>(path);
        }
    }
}
