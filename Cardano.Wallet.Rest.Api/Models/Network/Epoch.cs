using Cardano.Core.Nomenclatures;
using Cardano.Wallet.Rest.Api.Models.Common;
using System.Text.Json.Serialization;

namespace Cardano.Wallet.Rest.Api.Models.Network
{
	public class Epoch : Metric<ulong>
	{
		[JsonPropertyName("quantity")]
		public override ulong Quantity { get; set; }

		[JsonPropertyName("unit")]
		public override string Unit { get; set; } = UnitEnum.Slot.GetValue();
	}
}
