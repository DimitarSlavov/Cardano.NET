using System.Text.Json.Serialization;

namespace Cardano.Wallet.Rest.Api.Models.Common
{
    public class EstimatedFee
    {
        [JsonPropertyName("estimated_min")]
        public Fund EstimatedMin { get; set; }

        [JsonPropertyName("estimated_max")]
        public Fund EstimatedMax { get; set; }
    }
}
