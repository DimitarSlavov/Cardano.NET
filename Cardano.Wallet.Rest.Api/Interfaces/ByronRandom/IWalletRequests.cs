using Cardano.Core.Models.Common;
using Cardano.Wallet.Rest.Api.Models.Byron.Wallet;
using Cardano.Wallet.Rest.Api.Models.Wallet;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cardano.Wallet.Rest.Api.Interfaces.ByronRandom
{
    public interface IByronWalletRequests
    {
        /// <summary>
        /// Restore a Byron wallet from a mnemonic sentence or encrypted root private key.
        /// </summary>
        /// <returns>
        /// 201 Created,
        /// 400 Bad Request,
        /// 405 Method Not Allowed,
        /// 406 Not Acceptable,
        /// 409 Conflict,
        /// 415 Unsupported Media Type
        /// </returns>
        Task<Response<ByronWalletModel>> RestoreAsync<TModel>(
            TModel walletRestoreModel)
            where TModel : ByronWalletMetadata;

        /// <summary>
        /// Return a list of known Byron wallets, ordered from oldest to newest.
        /// </summary>
        /// <returns>
        /// 200 Ok,
        /// 405 Method Not Allowed,
        /// 406 Not Acceptable
        /// </returns>
        Task<Response<IEnumerable<ByronWalletModel>>> GetListAsync();

        /// <summary>
        /// Return the UTxOs distribution across the whole wallet, in the form of a histogram.
        /// </summary>
        /// <returns>
        /// 200 Ok,
        /// 404 Not Found,
        /// 405 Method Not Allowed,
        /// 406 Not Acceptable
        /// </returns>
        Task<Response<UTxOStatistics>> GetUTxOStatisticsAsync(
            string walletId);

        /// <summary>
        /// Return information about a Byron wallet.
        /// </summary>
        /// <returns>
        /// 200 Ok,
        /// 404 Not Found,
        /// 405 Method Not Allowed,
        /// 406 Not Acceptable
        /// </returns>
        Task<Response<ByronWalletModel>> GetByIdAsync(
            string walletId);

        /// <summary>
        /// Delete a Byron wallet.
        /// </summary>
        /// <returns>
        /// 204 No Content,
        /// 404 Not Found,
        /// 405 Method Not Allowed,
        /// 406 Not Acceptable
        /// </returns>
        Task<Response> DeleteAsync(
            string walletId);

        /// <returns>
        /// 200 Ok,
        /// 400 Bad Request,
        /// 404 Not Found,
        /// 405 Method Not Allowed,
        /// 406 Not Acceptable,
        /// 415 Unsupported Media Type
        /// </returns>
        Task<Response<ByronWalletModel>> UpdateMetadataAsync(
            string walletId,
            ByronWalletMetadata data);

        /// <returns>
        /// 204 No Content,
        /// 400 Bad Request,
        /// 403 Forbidden,
        /// 404 Not Found,
        /// 405 Method Not Allowed,
        /// 406 Not Acceptable,
        /// 415 Unsupported Media Type
        /// </returns>
        Task<Response> UpdatePassphraseAsync(
            string walletId,
            PassphraseUpdateResponse data);
    }
}
