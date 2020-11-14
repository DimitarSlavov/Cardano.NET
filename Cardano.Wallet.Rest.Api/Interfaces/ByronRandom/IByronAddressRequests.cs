using Cardano.Core.Models.Common;
using Cardano.Core.Nomenclatures;
using Cardano.Wallet.Rest.Api.Models.Address;
using Cardano.Wallet.Rest.Api.Models.Byron.Address;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cardano.Wallet.Rest.Api.Interfaces.ByronRandom
{
    public interface IByronAddressRequests
    {
        /// <summary>
        /// ⚠️ This endpoint is available for random wallets only. Any attempt to call this endpoint on another type of wallet will result in a 403 Forbidden error from the server.
        /// </summary>
        /// <returns>
        /// 201 Created,
        /// 400 Bad Request,
        /// 403 Forbidden,
        /// 405 Method Not Allowed,
        /// 406 Not Acceptable,
        /// 415 Unsupported Media Type
        /// </returns>
        Task<Response<Address>> CreateAddressAsync(string walletId, AddressCreationCredentials credentials);

        /// <summary>
        /// Return a list of known addresses, ordered from newest to oldest for sequential wallets. Arbitrarily ordered for random wallets.
        /// </summary>
        /// <returns>
        /// 200 Ok,
        /// 400 Bad Request,
        /// 404 Not Found,
        /// 405 Method Not Allowed,
        /// 406 Not Acceptable
        /// </returns>
        Task<Response<IEnumerable<Address>>> GetListAsync(string walletId, AddressStateEnum state = null);

        /// <summary>
        /// ⚠️ This endpoint is available for random wallets only. Any attempt to call this endpoint on another type of wallet will result in a 403 Forbidden error from the server.
        /// </summary>
        /// <returns>
        /// 204 No Content,
        /// 400 Bad Request,
        /// 403 Forbidden,
        /// 405 Method Not Allowed
        Task<Response> ImportAddressesAsync(string walletId, IEnumerable<string> addresses);

        /// <summary>
        /// ⚠️ This endpoint is available for random wallets only. Any attempt to call this endpoint on another type of wallet will result in a 403 Forbidden error from the server.
        /// </summary>
        /// <returns>
        /// 204 No Content,
        /// 400 Bad Request,
        /// 403 Forbidden,
        /// 405 Method Not Allowed
        /// </returns>
        Task<Response> ImportAddressAsync(string walletId, string addressId);
    }
}