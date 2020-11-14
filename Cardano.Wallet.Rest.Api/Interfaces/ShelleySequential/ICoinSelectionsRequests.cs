using Cardano.Core.Models.Common;
using Cardano.Wallet.Rest.Api.Models.CoinSelections;
using Cardano.Wallet.Rest.Api.Models.Common;
using System.Threading.Tasks;

namespace Cardano.Wallet.Rest.Api.Interfaces.ShelleySequential
{
	public interface ICoinSelectionRequests
	{
		/// <summary>
		/// Select coins to cover the given set of payments. Uses the Random-Improve coin selection algorithm (https://iohk.io/blog/self-organisation-in-coin-selection)
		/// </summary>
		/// <returns>
		/// 200 Ok,
		/// 400 Bad Request,
		/// 403 Forbidden,
		/// 404 Not Found,
		/// 405 Method Not Allowed,
		/// 406 Not Acceptable,
		/// 415 Unsupported Media Type
		/// </returns>
		Task<Response<TransactionFlow>> SelectCoins(string walletId, RandomSelection payments);
	}
}
