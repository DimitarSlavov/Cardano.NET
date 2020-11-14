using Cardano.Core.Nomenclatures;
using Cardano.Core.Models.Common;
using Cardano.Wallet.Rest.Api.Models.Address;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cardano.Wallet.Rest.Api.Interfaces.ShelleySequential
{
	public interface IAddressRequests
	{
		/// <summary>
		/// Return a list of known addresses, ordered from newest to oldest.
		/// </summary>
		/// <returns>
		/// 200 Ok,
		/// 400 Bad Request,
		/// 404 Not Found,
		/// 405 Method Not Allowed,
		/// 406 Not Acceptable
		/// </returns>
		Task<Response<IEnumerable<Address>>> GetListAsync(string walletId, AddressStateEnum state = null);
	}
}
