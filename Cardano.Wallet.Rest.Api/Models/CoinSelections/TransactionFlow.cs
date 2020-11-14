using Cardano.Wallet.Rest.Api.Models.Common;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Cardano.Wallet.Rest.Api.Models.CoinSelections
{
	public class TransactionFlow
	{
		[JsonPropertyName("inputs")]
		public IEnumerable<Input> Inputs { get; set; }

		[JsonPropertyName("outputs")]
		public IEnumerable<Output> Outputs { get; set; }
	}
}
