using System.Text.Json.Serialization;

namespace Cardano.Wallet.Rest.Api.Models.Proxy
{
	public class ExternalTransaction
	{
		[JsonPropertyName("id")]
		public string Id { get; set; }
	}
}
