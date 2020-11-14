using Cardano.Wallet.Rest.Api.Models.Common;
using System.Text.Json.Serialization;

namespace Cardano.Wallet.Rest.Api.Models.Wallet
{
	public abstract class WalletModel : WalletModelBase
	{
		/// <summary>
		/// A unique identifier for the wallet
		/// </summary>
		[JsonPropertyName("id")]
		public string Id { get; set; }

		/// <summary>
		/// Information about the wallet's passphrase
		/// </summary>
		[JsonPropertyName("passphrase")]
		public Passphrase Passphrase { get; set; }

		/// <summary>
		/// Whether a wallet is ready to use or still syncing
		/// </summary>
		[JsonPropertyName("state")]
		public State State { get; set; }

		/// <summary>
		///	A reference to a particular block
		/// </summary>
		[JsonPropertyName("tip")]
		public Tip Tip { get; set; }
	}
}
