using Cardano.Wallet.Rest.Api.Interfaces.Miscellaneous;
using Cardano.Core.Models.Common;
using System.Threading.Tasks;
using Cardano.Core.Http;
using Cardano.Wallet.Rest.Api.Models.Proxy;
using Cardano.Wallet.Rest.Api.Common;
using System.Net.Mime;
using Cardano.Core.Http.Requests.Interfaces;

namespace Cardano.Wallet.Rest.Api.Implementation.Miscellaneous
{
	internal class ProxyRequests : IProxyRequests
	{
        private readonly IPostRequests postRequests;

        public ProxyRequests(IPostRequests postRequests)
        {
            this.postRequests = postRequests;
        }

        public async Task<Response<ExternalTransaction>> PostExternalTransactionAsync(
			byte[] signedTransactionMessage)
        {
			var path = HttpHelper.UrlCombine(
				PathConstants.Proxy,
				PathConstants.Transactions);

			return await postRequests.PostAsync<ExternalTransaction, byte[]>(
				path,
				signedTransactionMessage,
                MediaTypeNames.Application.Octet);
		}
	}
}
