using Cardano.Core.Nomenclatures;
using Cardano.Wallet.Rest.Api.Models.Common;
using System.Text.Json.Serialization;

namespace Cardano.Wallet.Rest.Api.Models.Network
{
	public class Slot : Metric<float>
	{
		[JsonPropertyName("quantity")]
		public override float Quantity { get; set; }

		[JsonPropertyName("unit")]
		public override string Unit { get; set; } = UnitEnum.Second.GetValue();
	}
}
