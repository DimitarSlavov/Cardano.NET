using Cardano.Core.Models.Common;
using Cardano.Wallet.Rest.Api.Models.Network;
using System.Threading.Tasks;

namespace Cardano.Wallet.Rest.Api.Interfaces.Miscellaneous
{
	public interface INetworkRequests
	{
		/// <returns>
		/// 200 Ok,
		/// 405 Method Not Allowed,
		/// 406 Not Acceptable
		/// </returns>
		Task<Response<NetworkInformation>> GetInformationAsync();

		/// <returns>
		/// 200 Ok,
		/// 405 Method Not Allowed,
		/// 406 Not Acceptable
		/// </returns>
		Task<Response<NtpCheck>> GetClockAsync(bool forceNtpCheck = false);

		/// <summary>
		/// Returns the set of network parameters for the current epoch.
		/// </summary>
		/// <returns>
		/// 200 Ok,
		/// 405 Method Not Allowed,
		/// 406 Not Acceptable
		/// </returns>
		Task<Response<NetworkParameters>> GetParametersAsync();
	}
}
