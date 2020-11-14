using System.Text.Json.Serialization;

namespace Cardano.Wallet.Rest.Api.Models.StakePool
{
    public abstract class MetadataBase
    {
		[JsonPropertyName("ticker")]
		public string Ticker { get; set; }

		[JsonPropertyName("name")]
		public string Name { get; set; }

		[JsonPropertyName("description")]
		public string Description { get; set; }

		[JsonPropertyName("homepage")]
		public string HomepageUrl { get; set; }
	}
}
