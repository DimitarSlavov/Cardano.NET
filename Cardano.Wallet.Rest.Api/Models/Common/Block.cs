using System.Text.Json.Serialization;

namespace Cardano.Wallet.Rest.Api.Models.Common
{
	public class Block
	{
		[JsonPropertyName("slot_number")]
		public ulong SlotNumber { get; set; }

		[JsonPropertyName("epoch_number")]
		public ulong EpochNumber { get; set; }
	}
}
