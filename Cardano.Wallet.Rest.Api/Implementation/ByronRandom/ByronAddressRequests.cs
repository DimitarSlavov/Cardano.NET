using Cardano.Core.Http;
using Cardano.Core.Http.Requests.Interfaces;
using Cardano.Core.Models.Common;
using Cardano.Core.Nomenclatures;
using Cardano.Wallet.Rest.Api.Common;
using Cardano.Wallet.Rest.Api.Interfaces.ByronRandom;
using Cardano.Wallet.Rest.Api.Models.Address;
using Cardano.Wallet.Rest.Api.Models.Byron.Address;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cardano.Wallet.Rest.Api.Implementation.ByronRandom
{
    internal class ByronAddressRequests : IByronAddressRequests
    {
        private readonly IGetRequests getRequests;
        private readonly IPostRequests postRequests;
        private readonly IPutRequests putRequests;

        public ByronAddressRequests(IGetRequests getRequests,
            IPostRequests postRequests,
            IPutRequests putRequests)
        {
            this.getRequests = getRequests;
            this.postRequests = postRequests;
            this.putRequests = putRequests;
        }

        public async Task<Response<Address>> CreateAddressAsync(
            string walletId,
            AddressCreationCredentials credentials)
        {
            var path = HttpHelper.UrlCombine(
                PathConstants.ByronWallets,
                walletId,
                PathConstants.Addresses);

            return await postRequests.PostAsync<Address, AddressCreationCredentials>(path, credentials);
        }

        public async Task<Response<IEnumerable<Address>>> GetListAsync(
            string walletId,
            AddressStateEnum state = null)
        {
            var path = HttpHelper.UrlCombine(
                PathConstants.ByronWallets,
                walletId,
                PathConstants.Addresses)
                    .AppendQuery(nameof(state), state);

            return await getRequests.GetAsync<IEnumerable<Address>>(path);
        }

        public async Task<Response> ImportAddressesAsync(
            string walletId, 
            IEnumerable<string> addresses)
        {
            var path = HttpHelper.UrlCombine(
                PathConstants.ByronWallets,
                walletId,
                PathConstants.Addresses);

            return await putRequests.PutAsync(path, addresses);
        }

        public async Task<Response> ImportAddressAsync(
            string walletId,
            string addressId)
        {
            var path = HttpHelper.UrlCombine(
                PathConstants.ByronWallets,
                walletId,
                PathConstants.Addresses,
                addressId);

            return await putRequests.PutAsync(path);
        }
    }
}
