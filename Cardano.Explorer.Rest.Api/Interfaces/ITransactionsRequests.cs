using Cardano.Core.Models.Common;
using Cardano.Explorer.Rest.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cardano.Explorer.Rest.Api.Interfaces
{
    public interface ITransactionsRequests
    {
        /// <summary>
        /// Get summary information about a transaction.
        /// </summary>
        /// <returns>
        /// 200 Ok
        /// </returns>
        Task<Response<Right<TransactionSummaryInformation>>> GetTransactionInformationSummaryAsync(string txId);

        /// <summary>
        /// Get brief information about transactions.
        /// </summary>
        /// <returns>
        /// 200 Ok
        /// </returns>
        Task<Response<Right<IEnumerable<TransactionInformation>>>> GetTransactionsAsync();

        /// <returns>
        /// 200 Ok
        /// </returns>
        Task<Response<Right<TransactionStatsPage>>> GetTransactionsStatsAsync(uint page);
    }
}