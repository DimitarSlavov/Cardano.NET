using Cardano.Wallet.Rest.Api.Models.Common;
using Cardano.Wallet.Rest.Api.Models.Wallet;
using System.Text.Json.Serialization;

namespace Cardano.Wallet.Rest.Api.Models.Shelly
{
    public class ShellyBalance : Balance
    {
        /// <summary>
        /// The balance of the reward account for this wallet
        /// </summary>
        [JsonPropertyName("reward")]
        public Fund Reward { get; set; }
    }
}
