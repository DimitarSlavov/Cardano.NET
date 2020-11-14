using Cardano.Explorer.Rest.Api.Models;
using Cardano.Core.Models.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cardano.Explorer.Rest.Api.Interfaces
{
    public interface IEpochsRequests
    {
        /// <summary>
        /// Get epoch pages, all the paged slots in the epoch.
        /// </summary>
        /// <returns>
        /// 200 Ok
        /// </returns>
        Task<Response<Right<BlockPage>>> GetEpochAsync(ulong epoch, uint page);

        /// <summary>
        /// Get the slot information in an epoch.
        /// </summary>
        /// <returns>
        /// 200 Ok
        /// </returns>
        Task<Response<Right<IEnumerable<Block>>>> GetTotalPagesAsync(ulong epoch, ushort slot);
    }
}