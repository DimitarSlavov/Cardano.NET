using Cardano.Wallet.Rest.Api.Models.Common;
using System.Text.Json.Serialization;

namespace Cardano.Wallet.Rest.Api.Models.Wallet
{
	public class CreateRestoreWallet1 : WalletModelBase
	{
		/// <summary>
		/// An extended account public key (public key + chain code)
		/// </summary>
		[JsonPropertyName("account_public_key")]
		public string AccountPublicKey { get; set; }
	}
}
