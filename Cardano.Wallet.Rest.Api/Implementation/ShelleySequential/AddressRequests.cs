using Cardano.Wallet.Rest.Api.Interfaces.ShelleySequential;
using Cardano.Core.Models.Common;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cardano.Core.Http;
using Cardano.Wallet.Rest.Api.Models.Address;
using Cardano.Wallet.Rest.Api.Common;
using Cardano.Core.Nomenclatures;
using Cardano.Core.Http.Requests.Interfaces;

namespace Cardano.Wallet.Rest.Api.Implementation.ShelleySequential
{
	internal class AddressRequests : IAddressRequests
	{
		private readonly IGetRequests getRequests;

		public AddressRequests(IGetRequests getRequests)
		{
			this.getRequests = getRequests;
		}

		public async Task<Response<IEnumerable<Address>>> GetListAsync(
			string walletId,
			AddressStateEnum state = null)
		{
			var path = HttpHelper.UrlCombine(
				PathConstants.Wallets, 
				walletId, 
				PathConstants.Addresses)
					.AppendQuery(nameof(state), state);

			return await getRequests.GetAsync<IEnumerable<Address>>(path);
		}
	}
}
