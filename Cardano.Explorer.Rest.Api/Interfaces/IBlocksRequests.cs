using Cardano.Core.Models.Common;
using Cardano.Explorer.Rest.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cardano.Explorer.Rest.Api.Interfaces
{
    public interface IBlocksRequests
    {
        /// <summary>
        /// Get the list of blocks, contained in pages.
        /// </summary>
        /// <returns>
        /// 200 Ok
        /// </returns>
        Task<Response<Right<BlockPage>>> GetBlocksAsync(uint page, uint pageSize);

        /// <summary>
        /// Get block's summary information.
        /// </summary>
        /// <returns>
        /// 200 Ok
        /// </returns>
        Task<Response<Right<BlockSummaryInformation>>> GetBlockSummaryAsync(string blockHash);

        /// <summary>
        /// Get the list of total pages.
        /// </summary>
        /// <returns>
        /// 200 Ok
        /// </returns>
        Task<Response<Right<ulong>>> GetTotalPagesAsync(uint pageSize);

        /// <summary>
        /// Get brief information about transactions.
        /// </summary>
        /// <returns>
        /// 200 Ok
        /// </returns>
        Task<Response<Right<IEnumerable<Transaction>>>> GetTransactionsAsync(string blockHash, ulong limit, ulong offset);
    }
}