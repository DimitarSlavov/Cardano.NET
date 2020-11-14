using System.Text.Json.Serialization;

namespace Cardano.Wallet.Rest.Api.Models.Common
{
	public class Input : Payment
	{
		[JsonPropertyName("id")]
		public string Id { get; set; }
		
		[JsonPropertyName("index")]
		public ulong Index { get; set; }
	}
}
