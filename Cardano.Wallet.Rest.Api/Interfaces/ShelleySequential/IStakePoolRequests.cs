using Cardano.Core.Models.Common;
using Cardano.Wallet.Rest.Api.Models.Common;
using Cardano.Wallet.Rest.Api.Models.StakePool;
using Cardano.Wallet.Rest.Api.Models.Transaction;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cardano.Wallet.Rest.Api.Interfaces.ShelleySequential
{
	public interface IStakePoolRequests
	{
		/// <summary>
		/// List all known stake pools ordered by descending desirability. Some pools may also have metadata attached to them if they have been registered to the metadata registry.
		/// </summary>
		/// <returns>
		/// 200 Ok,
		/// 404 Not Found,
		/// 405 Method Not Allowed
		/// </returns>
		Task<Response<IEnumerable<TStakePoolModel>>> GetAllAsync<TStakePoolModel>(long stake) where TStakePoolModel : StakePoolBase;

		/// <summary>
		/// Estimate fee for joining or leaving a stake pool. Note that it is an estimation because a delegation induces a transaction for which coins have to be selected randomly within the wallet. Because of this randomness, fees can only be estimated.
		/// </summary>
		/// <returns>
		/// 200 Ok,
		/// 403 Forbidden,
		/// 404 Not Found,
		/// 405 Method Not Allowed,
		/// 406 Not Acceptable
		/// </returns>
		Task<Response<EstimatedFee>> GetEstimateFeeAsync(string walletId);

		/// <summary>
		/// Stop delegating completely. The wallet's stake will become inactive.
		/// Disclaimer:
		/// This endpoint historically use to take a stake pool id as a path parameter. However, retiring from delegation is ubiquitous and not tight to a particular stake pool. For backward-compatibility reasons, sending stake pool ids as path parameter will still be accepted by the server but new integrations are encouraged to provide a placeholder asterisk * instead.
		/// </summary>
		/// <returns>
		/// 202 Accepted,
		/// 400 Bad Request,
		/// 403 Forbidden,
		/// 404 Not Found,
		/// 405 Method Not Allowed,
		/// 406 Not Acceptable,
		/// 415 Unsupported Media Type
		/// </returns>
		Task<Response<Transaction>> QuitDelegatingAsync(string walletId, WalletPassphrase data);

		/// <summary>
		/// Delegate all (current and future) addresses from the given wallet to the given stake pool.
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
		Task<Response<Transaction>> JoinOneAsync(string walletId, string stakePoolId, WalletPassphrase data);
	}
}
