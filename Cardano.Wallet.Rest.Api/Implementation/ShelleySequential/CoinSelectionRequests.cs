using Cardano.Wallet.Rest.Api.Interfaces.ShelleySequential;
using Cardano.Core.Models.Common;
using System.Threading.Tasks;
using Cardano.Core.Http;
using Cardano.Wallet.Rest.Api.Models.CoinSelections;
using Cardano.Wallet.Rest.Api.Models.Common;
using Cardano.Wallet.Rest.Api.Common;
using Cardano.Core.Http.Requests.Interfaces;

namespace Cardano.Wallet.Rest.Api.Implementation.ShelleySequential
{
	internal class CoinSelectionRequests : ICoinSelectionRequests
	{
		private readonly IPostRequests postRequests;

		public CoinSelectionRequests(IPostRequests postRequests)
		{
			this.postRequests = postRequests;
		}

		public async Task<Response<TransactionFlow>> SelectCoins(
			string walletId,
			RandomSelection payments)
		{
			var path = HttpHelper.UrlCombine(
				PathConstants.Wallets,
				walletId,
				PathConstants.CoinSelections,
				PathConstants.Random);

			return await postRequests.PostAsync<TransactionFlow, RandomSelection>(path, payments);
		}
	}
}
