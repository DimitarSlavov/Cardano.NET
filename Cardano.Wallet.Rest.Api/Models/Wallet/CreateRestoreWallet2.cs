using Cardano.Wallet.Rest.Api.Models.Common;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Cardano.Wallet.Rest.Api.Models.Wallet
{
	public class CreateRestoreWallet2 : WalletModelBase
	{
		/// <summary>
		/// A list of mnemonic words
		/// </summary>
		[JsonPropertyName("mnemonic_sentence")]
		public IEnumerable<string> MnemonicSentence { get; set; }

		/// <summary>
		/// An optional passphrase used to encrypt the mnemonic sentence
		/// </summary>
		[JsonPropertyName("mnemonic_second_factor")]
		public IEnumerable<string> MnemonicSecondFactor { get; set; }

		/// <summary>
		/// A master passphrase to lock and protect the wallet for sensitive operation (e.g. sending funds)
		/// </summary>
		[JsonPropertyName("passphrase")]
		public string Passphrase { get; set; }
	}
}
