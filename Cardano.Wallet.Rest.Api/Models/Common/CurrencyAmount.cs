using System.Text.Json.Serialization;

namespace Cardano.Wallet.Rest.Api.Models.Common
{
	public class CurrencyAmount
	{       
		/// <summary>
		/// Coins, in Lovelace
		/// </summary>
		[JsonPropertyName("amount")]
		public Fund Amount { get; set; }
	}
}
