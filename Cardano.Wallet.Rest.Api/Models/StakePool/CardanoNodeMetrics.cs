using Cardano.Wallet.Rest.Api.Models.Common;
using System.Text.Json.Serialization;

namespace Cardano.Wallet.Rest.Api.Models.StakePool
{
    public class CardanoNodeMetrics
    {
        [JsonPropertyName("non_myopic_member_rewards")]
        public Fund NonMyopicMemberRewards { get; set; }

        [JsonPropertyName("relative_stake")]
        public Progress RelativeStake { get; set; }

        [JsonPropertyName("saturation")]
        public float Saturation { get; set; }

        [JsonPropertyName("produced_blocks")]
        public BlockHeight ProducedBlocks { get; set; }
    }
}
