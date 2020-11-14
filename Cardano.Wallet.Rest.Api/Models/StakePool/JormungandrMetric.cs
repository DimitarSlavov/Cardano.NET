using Cardano.Wallet.Rest.Api.Models.Common;
using System.Text.Json.Serialization;

namespace Cardano.Wallet.Rest.Api.Models.StakePool
{
	public class JormungandrMetric
	{
		/// <summary>
		/// Coins, in Lovelace
		/// </summary>
		[JsonPropertyName("controlled_stake")]
		public Fund ControlledStake { get; set; }

		[JsonPropertyName("produced_blocks")]
		public BlockHeight ProducedBlocks { get; set; }
	}
}
