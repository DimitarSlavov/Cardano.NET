using Cardano.Wallet.Rest.Api.Models.StakePool;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Cardano.Wallet.Rest.Api.Models.Byron.Migration
{
    public class MigrationData : WalletPassphrase
    {
        [JsonPropertyName("addresses")]
        public IEnumerable<string> Addresses { get; set; }
    }
}
