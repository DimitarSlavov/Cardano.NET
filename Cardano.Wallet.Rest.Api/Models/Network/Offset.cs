using Cardano.Core.Nomenclatures;
using Cardano.Wallet.Rest.Api.Models.Common;
using System.Text.Json.Serialization;

namespace Cardano.Wallet.Rest.Api.Models.Network
{
	public class Offset : Metric<long>
	{
		[JsonPropertyName("quantity")]
		public override long Quantity { get; set; }

		[JsonPropertyName("unit")]
		public override string Unit { get; set; } = UnitEnum.Microsecond.GetValue();
	}
}
