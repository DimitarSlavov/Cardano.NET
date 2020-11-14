using Cardano.Core.Models.Common;
using Cardano.Explorer.Rest.Api.Models;
using System.Threading.Tasks;

namespace Cardano.Explorer.Rest.Api.Interfaces
{
    public interface IAddressesRequests
    {
        /// <returns>
        /// 200 Ok
        /// </returns>
        Task<Response<Right<Address>>> GetAddressAsync(string blockHash, string address);

        /// <summary>
        /// Get summary information about an address.
        /// </summary>
        /// <returns>
        /// 200 Ok
        /// </returns>
        Task<Response<Right<Address>>> GetAddressSummaryAsync(string address);
    }
}