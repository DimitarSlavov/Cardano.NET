using System.Text.Json.Serialization;

namespace Cardano.Wallet.Rest.Api.Models.Common
{
	public abstract class WalletMetadata
	{
		[JsonPropertyName("name")]
		public string Name { get; set; }
	}
}
