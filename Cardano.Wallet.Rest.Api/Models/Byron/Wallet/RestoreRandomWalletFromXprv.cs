using Cardano.Core.Nomenclatures;
using System.Text.Json.Serialization;

namespace Cardano.Wallet.Rest.Api.Models.Byron.Wallet
{
    public class RestoreRandomWalletFromXprv : ByronWalletMetadata
    {
        /// <summary>
        /// Value: "random"
        /// </summary>
        [JsonPropertyName("style")]
        public string Style { get; set; } = WalletStyleEnum.Random.GetValue();

        /// <summary>
        /// A root private key, encrypted using a given passphrase. The underlying key should contain:
        /// 1. A private key
        /// 2. A chain code
        /// 3. A public key
        /// </summary>
        [JsonPropertyName("encrypted_root_private_key")]
        public string EncryptedRootPrivateKey { get; set; }

        /// <summary>
        /// A hash of master passphrase. The hash should be an output of a Scrypt function with the following parameters:
        /// 1. logN = 14
        /// 2. r = 8
        /// 3. p = 1
        /// </summary>

        [JsonPropertyName("passphrase_hash")]
        public string PassphraseHash { get; set; }
    }
}
