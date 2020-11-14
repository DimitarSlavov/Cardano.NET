using Cardano.Wallet.Rest.Api.Models.Wallet;
using System.Text.Json.Serialization;

namespace Cardano.Wallet.Rest.Api.Models.Shelly
{
    public class ShellyWalletModel : WalletModel
    {
        /// <summary>
        /// Wallet current balance(s)
        /// </summary>
        [JsonPropertyName("balance")]
        public ShellyBalance Balance { get; set; }

        /// <summary>
        /// Delegation settings
        /// </summary>
        [JsonPropertyName("delegation")]
        public Delegation Delegation { get; set; }
    }
}
