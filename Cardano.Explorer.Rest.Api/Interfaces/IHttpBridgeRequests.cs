using Cardano.Core.Models.Common;
using Cardano.Core.Nomenclatures;
using Cardano.Explorer.Rest.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cardano.Explorer.Rest.Api.Interfaces
{
    public interface IHttpBridgeRequests
    {
        /// <summary>
        /// Get current balance of provided address.
        /// </summary>
        /// <returns>
        /// 200 Ok
        /// </returns>
        Task<Response<IEnumerable<AddressBalance>>> GetAddressBalanceAsync(NetworkEnum network, string address);
    }
}