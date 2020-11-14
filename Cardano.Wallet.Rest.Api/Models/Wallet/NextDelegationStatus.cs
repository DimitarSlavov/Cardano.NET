using Cardano.Wallet.Rest.Api.Models.Common;
using System.Text.Json.Serialization;

namespace Cardano.Wallet.Rest.Api.Models.Wallet
{
	public class NextDelegationStatus : DelegationStatus
	{
		[JsonPropertyName("changes_at")]
		public ChangesAt ChangesAt { get; set; }
	}
}
