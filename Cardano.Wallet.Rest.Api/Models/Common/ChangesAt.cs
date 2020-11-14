using System.Text.Json.Serialization;

namespace Cardano.Wallet.Rest.Api.Models.Common
{
	public class ChangesAt
	{
		[JsonPropertyName("epoch_number")]
		public ulong EpochNumber { get; set; }

		[JsonPropertyName("epoch_start_time")]
		public string EpochStartTime { get; set; }
	}
}
