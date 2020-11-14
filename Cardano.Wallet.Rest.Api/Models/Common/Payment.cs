using System.Text.Json.Serialization;

namespace Cardano.Wallet.Rest.Api.Models.Common
{
	public class Payment : CurrencyAmount
	{
		[JsonPropertyName("address")]
		public string Address { get; set; }
	}
}
