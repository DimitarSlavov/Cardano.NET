using Cardano.Core.Nomenclatures;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Cardano.Wallet.Rest.Api.Models.Byron.Wallet
{
    public class RestoreWalletStyle : RestoreWalletGenericBase
    {
        public RestoreWalletStyle(WalletStyleEnum styte)
        {
            this.Style = styte.GetValue();
        }

        [JsonPropertyName("style")]
        public string Style { get; }

        [JsonPropertyName("mnemonic_sentence")]
        public IEnumerable<string> MnemonicSentence { get; set; }
    }
}
