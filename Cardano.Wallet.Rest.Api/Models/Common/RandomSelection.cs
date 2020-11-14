using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Cardano.Wallet.Rest.Api.Models.Common
{
	public class RandomSelection
	{
		[JsonPropertyName("payments")]
		public IEnumerable<Payment> Payments { get; set; }
	}
}
