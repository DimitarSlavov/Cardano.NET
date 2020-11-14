using Cardano.Core.Nomenclatures;
using System.Text.Json.Serialization;

namespace Cardano.Wallet.Rest.Api.Models.Common
{
	public class Progress : Metric<float>
	{
		[JsonPropertyName("quantity")]
		public override float Quantity { get; set; }

		[JsonPropertyName("unit")]
		public override string Unit { get; set; } = UnitEnum.Percent.GetValue();
	}
}
