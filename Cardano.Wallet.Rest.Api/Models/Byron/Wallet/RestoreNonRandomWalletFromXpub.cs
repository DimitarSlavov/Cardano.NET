using Cardano.Wallet.Rest.Api.Common;
using Cardano.Wallet.Rest.Api.Models.Common;
using System.Text.Json.Serialization;

namespace Cardano.Wallet.Rest.Api.Models.Byron.Wallet
{
    public class RestoreNonRandomWalletFromXpub : WalletMetadata
    {
        /// <summary>
        /// An extended account public key (public key + chain code)    
        /// </summary>
        [JsonPropertyName("account_public_key")]
        public string AccountPublicKey { get; set; }

        /// <summary>
        /// Number of consecutive unused addresses allowed
        /// </summary>
        [JsonPropertyName("address_pool_gap")]
        public byte AddressPoolGap { get; set; } = DefaultValueConstants.AddressPoolGap;
    }
}
