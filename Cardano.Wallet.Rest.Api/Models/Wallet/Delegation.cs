using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Cardano.Wallet.Rest.Api.Models.Wallet
{
	public class Delegation
	{
		/// <summary>
		/// Currently active delegation status
		/// </summary>
		[JsonPropertyName("active")]
		public DelegationStatus Active { get; set; }

		[JsonPropertyName("next")]
		public IEnumerable<NextDelegationStatus> Next { get; set; }
	}
}
