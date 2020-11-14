using Cardano.Wallet.Rest.Api.Interfaces.Miscellaneous;
using Cardano.Core.Models.Common;
using System.Threading.Tasks;
using Cardano.Core.Http;
using Cardano.Wallet.Rest.Api.Models.Network;
using Cardano.Wallet.Rest.Api.Common;
using System.Collections.Generic;
using Cardano.Core.Http.Requests.Interfaces;

namespace Cardano.Wallet.Rest.Api.Implementation.Miscellaneous
{
	internal class NetworkRequests : INetworkRequests
	{
		private readonly IGetRequests getRequests;

		public NetworkRequests(IGetRequests getRequests)
		{
			this.getRequests = getRequests;
		}

		public async Task<Response<NetworkInformation>> GetInformationAsync()
        {
			var path = HttpHelper.UrlCombine(
					PathConstants.Network,
					PathConstants.Information);

			return await getRequests.GetAsync<NetworkInformation>(path);
		}

		public async Task<Response<NtpCheck>> GetClockAsync(
			bool forceNtpCheck = false)
        {
			var path = HttpHelper.GetPathWithQueryParameters(
				HttpHelper.UrlCombine(
					PathConstants.Network, 
					PathConstants.Clock),
				new Dictionary<string, object> {
					{ nameof(forceNtpCheck), forceNtpCheck }
				});

			return await getRequests.GetAsync<NtpCheck>(path);
		}

		public async Task<Response<NetworkParameters>> GetParametersAsync()
        {
			var path = HttpHelper.UrlCombine(
				PathConstants.Network,
				PathConstants.Parameters);

			return await getRequests.GetAsync<NetworkParameters>(path);
		}
	}
}
