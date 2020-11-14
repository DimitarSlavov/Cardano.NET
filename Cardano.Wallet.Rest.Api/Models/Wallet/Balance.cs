using Cardano.Wallet.Rest.Api.Models.Common;
using System.Text.Json.Serialization;

namespace Cardano.Wallet.Rest.Api.Models.Wallet
{
	public class Balance
	{
		/// <summary>
		/// Available balance (funds that can be spent)
		/// </summary>
		[JsonPropertyName("available")]
		public Fund Available { get; set; }

		/// <summary>
		/// Total balance (available balance plus pending change)
		/// </summary>
		[JsonPropertyName("total")]
		public Fund Total { get; set; }
	}
}
