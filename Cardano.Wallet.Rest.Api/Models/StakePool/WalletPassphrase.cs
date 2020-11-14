using System.Text.Json.Serialization;

namespace Cardano.Wallet.Rest.Api.Models.StakePool
{
	public class WalletPassphrase
	{
		/// <summary>
		/// The source Byron wallet's master passphrase.
		/// </summary>
		[JsonPropertyName("passphrase")]
		public string Passphrase { get; set; }
	}
}
