using Cardano.Wallet.Rest.Api.Models.Common;
using System.Text.Json.Serialization;

namespace Cardano.Wallet.Rest.Api.Models.Network
{
	public class NetworkParameters
	{
		[JsonPropertyName("genesis_block_hash")]
		public string GenesisBlockHash { get; set; }

		[JsonPropertyName("blockchain_start_time")]
		public string BlockchainStartTime { get; set; }

		[JsonPropertyName("slot_length")]
		public Slot SlotLength { get; set; }

		[JsonPropertyName("epoch_length")]
		public Epoch EpochLength { get; set; }

		[JsonPropertyName("epoch_stability")]
		public BlockHeight EpochStability { get; set; }

		[JsonPropertyName("active_slot_coefficient")]
		public Progress ActiveSlotCoefficient { get; set; }
	}
}
