using System.Text.Json.Serialization;

namespace Cardano.Wallet.Rest.Api.Models.Wallet
{
	public class PassphraseUpdateResponse
	{
		/// <summary>
		/// The current passphrase
		/// </summary>
		[JsonPropertyName("old_passphrase")]
		public string OldPassphrase { get; set; }

		/// <summary>
		/// A master passphrase to lock and protect the wallet for sensitive operation (e.g. sending funds).
		/// </summary>
		[JsonPropertyName("new_passphrase")]
		public string NewPassphrase { get; set; }
	}
}
