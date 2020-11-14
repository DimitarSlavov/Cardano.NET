using Cardano.Core.Models.Common;
using Cardano.Wallet.Rest.Api.Models.CoinSelections;
using Cardano.Wallet.Rest.Api.Models.Common;
using System.Threading.Tasks;

namespace Cardano.Wallet.Rest.Api.Interfaces.ByronRandom
{
    public interface IByronCoinSelectionRequests
    {
        /// <summary>
        /// Select coins to cover the given set of payments.
        /// Uses the Random-Improve coin selection algorithm.
        /// </summary>
        /// <returns>
        /// 200 OK,
        /// 400 Bad Request,
        /// 403 Forbidden,
        /// 404 Not Found,
        /// 405 Method Not Allowed,
        /// 406 Not Acceptable,
        /// 415 Unsupported Media Type
        /// </returns>
        Task<Response<TransactionFlow>> SelectCoinsAsync(string walletId, RandomSelection payments);
    }
}