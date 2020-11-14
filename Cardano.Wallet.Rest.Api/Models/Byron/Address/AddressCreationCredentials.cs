using Cardano.Wallet.Rest.Api.Models.StakePool;
using System.Text.Json.Serialization;

namespace Cardano.Wallet.Rest.Api.Models.Byron.Address
{
    public class AddressCreationCredentials : WalletPassphrase
    {
        /// <summary>
        /// An optional address derivation index. Leave out to get an address with a randomly generated index.
        /// </summary>
        [JsonPropertyName("address_index")]
        public ulong? AddressIndex { get; set; }
    }
}
