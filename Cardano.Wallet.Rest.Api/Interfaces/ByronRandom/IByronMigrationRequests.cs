using Cardano.Core.Models.Common;
using Cardano.Wallet.Rest.Api.Models.Byron.Migration;
using Cardano.Wallet.Rest.Api.Models.Transaction;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cardano.Wallet.Rest.Api.Interfaces.ByronRandom
{
    public interface IByronMigrationRequests
    {
        /// <summary>
        /// Submit one or more transactions which transfers all funds from a Byron wallet to a set of addresses.
        /// This operation attempts to preserve the UTxO "shape" of a wallet as far as possible.That is, coins will not be agglomerated.Therefore, if the wallet has a large UTxO set, several transactions may be needed.
        /// A typical usage would be when one wants to move all funds from an old wallet to another(Shelley or Byron) by providing addresses coming from the new wallet.
        /// </summary>
        /// <returns>
        /// 200 Ok,
        /// 403 Forbidden,
        /// 404 Not Found,
        /// 405 Method Not Allowed,
        /// 406 Not Acceptable,
        /// 415 Unsupported Media Type
        /// </returns>
        Task<Response<IEnumerable<Transaction>>> MigrateAsync(
            string walletId,
            MigrationData migrationData);

        /// <summary>
        /// Calculate the exact cost of sending all funds from particular Byron wallet to a set of addresses.
        /// </summary>
        /// <returns>
        /// 200 Ok, 
        /// 404 Not Found, 
        /// 405 Method Not Allowed, 
        /// 406 Not Acceptable
        /// </returns>
        Task<Response<MigrationFullCost>> GetCostAsync(
            string walletId);
    }
}
