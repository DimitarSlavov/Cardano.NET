using System.Text.Json.Serialization;

namespace Cardano.Wallet.Rest.Api.Models.Wallet
{
	public class Passphrase
	{
		[JsonPropertyName("last_updated_at")]
		public string LastUpdatedAt { get; set; }
	}
}
