using Cardano.Core.Nomenclatures;
using System.Text.Json.Serialization;

namespace Cardano.Wallet.Rest.Api.Models.Common
{
	public class Fund : Metric<ulong>
	{
		[JsonPropertyName("quantity")]
		public override ulong Quantity { get; set; }

		[JsonPropertyName("unit")]
		public override string Unit { get; set; } = UnitEnum.Lovelace.GetValue();
	}
}
