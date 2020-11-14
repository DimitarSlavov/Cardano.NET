using Cardano.Core.Models.Common;
using Cardano.Wallet.Rest.Api.Models.Common;
using Cardano.Wallet.Rest.Api.Models.Shelly;
using Cardano.Wallet.Rest.Api.Models.Wallet;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cardano.Wallet.Rest.Api.Interfaces.ShelleySequential
{
	public interface IWalletRequests
	{
		/// <summary>
		/// Create and restore a wallet from a mnemonic sentence or account public key.
		/// </summary>
		/// <returns>
		/// 201 Created,
		/// 400 Bad Request,
		/// 405 Method Not Allowed,
		/// 406 Not Acceptable,
		/// 409 Conflict,
		/// 415 Unsupported Media Type
		/// </returns>
		Task<Response<ShellyWalletModel>> CreateOrRestoreAsync<D>(D data) where D : WalletModelBase;

		/// <summary>
		/// Return a list of known wallets, ordered from oldest to newest.
		/// </summary>
		/// <returns>
		/// 200 Ok,
		/// 405 Method Not Allowed,
		/// 406 Not Acceptable
		/// </returns>
		Task<Response<IEnumerable<ShellyWalletModel>>> GetListAsync();

		/// <summary>
		/// Return the UTxOs distribution across the whole wallet, in the form of a histogram.
		/// </summary>
		/// <returns>
		/// 200 Ok,
		/// 404 Not Found,
		/// 405 Method Not Allowed,
		/// 406 Not Acceptable
		/// </returns>
		Task<Response<UTxOStatistics>> GetUTxOStatisticsAsync(string walletId);

		/// <returns>
		/// 200 Ok,
		/// 404 Not Found,
		/// 405 Method Not Allowed,
		/// 406 Not Acceptable
		/// </returns>
		Task<Response<ShellyWalletModel>> GetByIdAsync(string walletId);

		/// <returns>
		/// 204 No Content,
		/// 404 Not Found,
		/// 405 Method Not Allowed,
		/// 406 Not Acceptable
		/// </returns>
		Task<Response> DeleteAsync(string walletId);

		/// <returns>
		/// 200 Ok,
		/// 400 Bad Request,
		/// 404 Not Found,
		/// 405 Method Not Allowed,
		/// 406 Not Acceptable,
		/// 415 Unsupported Media Type
		/// </returns>		
		Task<Response<ShellyWalletModel>> UpdateMetadataAsync(string walletId, WalletMetadata data);

		/// <returns>
		/// 204 No Content,
		/// 400 Bad Request,
		/// 403 Forbidden,
		/// 404 Not Found,
		/// 405 Method Not Allowed,
		/// 406 Not Acceptable,
		/// 415 Unsupported Media Type
		/// </returns>		
		Task<Response> UpdatePassphraseAsync(string walletId, PassphraseUpdateResponse data);
	}
}