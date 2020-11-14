using System.Text.Json.Serialization;

namespace Cardano.Wallet.Rest.Api.Models.Byron.Wallet
{
    public abstract class RestoreWalletGenericBase : ByronWalletMetadata
    {
        [JsonPropertyName("passphrase")]
        public string Passphrase { get; set; }
    }
}
