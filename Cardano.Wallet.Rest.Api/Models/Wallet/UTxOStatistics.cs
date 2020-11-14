using Cardano.Core;
using Cardano.Wallet.Rest.Api.Models.Common;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Cardano.Wallet.Rest.Api.Models.Wallet
{
	public class UTxOStatistics
	{
		/// <summary>
		/// Coins, in Lovelace
		/// </summary>
		[JsonPropertyName("total")]
		public Fund Total { get; set; }

		/// <summary>
		/// Value: "log10"
		/// </summary>
		[JsonPropertyName("scale")]
		public string Scale { get; set; } = Constants.UtxoScaleValue;

		[JsonPropertyName("distribution")]
		[JsonExtensionData]
		public IDictionary<string, long> Distribution { get; set; }
	}
}
