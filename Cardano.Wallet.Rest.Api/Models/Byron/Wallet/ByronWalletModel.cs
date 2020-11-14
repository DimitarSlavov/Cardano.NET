using Cardano.Core.Nomenclatures;
using Cardano.Wallet.Rest.Api.Models.Wallet;
using System.Text.Json.Serialization;

namespace Cardano.Wallet.Rest.Api.Models.Byron.Wallet
{
    public class ByronWalletModel : WalletModel
    {
        private DiscoveryEnum discovery;

        /// <summary>
        /// Wallet current balance(s)
        /// </summary>
        [JsonPropertyName("balance")]
		public ByronBalance Balance { get; set; }

		/// <summary>
		/// Mechanism used for discovering addresses.
		/// Enum: "random" "sequential"
		/// </summary>
		[JsonPropertyName("discovery")]
		public string Discovery
		{
            get => discovery.GetValue();
            set
            {
                if (DiscoveryEnum.Random.GetValue().Equals(value))
                {
                    discovery = DiscoveryEnum.Random;
                }
                else if (DiscoveryEnum.Sequential.GetValue().Equals(value))
                {
                    discovery = DiscoveryEnum.Sequential;
                }
            }
        }
    }
}
