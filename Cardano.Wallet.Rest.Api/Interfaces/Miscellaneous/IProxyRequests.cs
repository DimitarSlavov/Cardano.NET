using Cardano.Core.Models.Common;
using Cardano.Wallet.Rest.Api.Models.Proxy;
using System.Threading.Tasks;

namespace Cardano.Wallet.Rest.Api.Interfaces.Miscellaneous
{
	public interface IProxyRequests
	{
		/// <summary>
		/// Submits a transaction that was created and signed outside of cardano-wallet.
		/// </summary>
		/// <returns>
		/// 202 Accepted,
		/// 400 Bad Request,
		/// 405 Method Not Allowed,
		/// 406 Not Acceptable,
		/// 415 Unsupported Media Type
		/// </returns>
		Task<Response<ExternalTransaction>> PostExternalTransactionAsync(byte[] signedTransactionMessage);
	}
}
