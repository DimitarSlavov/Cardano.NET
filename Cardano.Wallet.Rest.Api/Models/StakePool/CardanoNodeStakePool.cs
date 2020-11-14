using Cardano.Wallet.Rest.Api.Models.Common;
using System.Text.Json.Serialization;

namespace Cardano.Wallet.Rest.Api.Models.StakePool
{
    public class CardanoNodeStakePool : StakePoolBase
    {
        [JsonPropertyName("metrics")]
        public CardanoNodeMetrics Metrics { get; set; }

        [JsonPropertyName("pledge")]
        public Fund Pledge { get; set; }

        [JsonPropertyName("metadata")]
        public CardanoNodeMetadata Metadata { get; set; }

        [JsonPropertyName("retirement")]
        public ChangesAt Retirement { get; set; }
    }
}
