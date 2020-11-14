using Cardano.Core.Models.Common;
using Cardano.Core.Nomenclatures;
using Cardano.Explorer.Rest.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cardano.Explorer.Rest.Api.Interfaces
{
    public interface IGenesisRequests
    {
        /// <returns>
        /// 200 Ok
        /// </returns>
        Task<Response<Right<IEnumerable<GenesisAddress>>>> GetAddressInfoAsync(uint page, uint pageSize, FilterEnum filter);

        /// <summary>
        /// Get information about the genesis block.
        /// </summary>
        /// <returns>
        /// 200 Ok
        /// </returns>
        Task<Response<Right<GenesisBlock>>> GetSummaryAsync();

        /// <summary>
        /// Get the total supply of Ada.
        /// </summary>
        /// <returns>
        /// 200 Ok
        /// </returns>
        Task<Response<Right<decimal>>> GetTotalAdaSupplyAsync();

        /// <returns>
        /// 200 Ok
        /// </returns>
        Task<Response<Right<ulong>>> GetTotalPagesAsync(uint pageSize, FilterEnum filter);
    }
}