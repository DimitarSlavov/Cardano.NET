using Cardano.Wallet.Rest.Api.Models.Common;
using System.Text.Json.Serialization;

namespace Cardano.Wallet.Rest.Api.Models.Byron.Migration
{
    public class MigrationFullCost
    {
        [JsonPropertyName("migration_cost")]
        public Fund MigrationCost { get; set; }

        [JsonPropertyName("leftovers")]
        public Fund Leftovers { get; set; }
    }
}
