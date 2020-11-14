using Cardano.Wallet.Rest.Api.Models.Common;
using System.Text.Json.Serialization;

namespace Cardano.Wallet.Rest.Api.Models.Transaction
{
	public class Inserted
	{
		[JsonPropertyName("time")]
		public string Time { get; set; }

		/// <summary>
		/// A reference to a particular block.
		/// </summary>
		[JsonPropertyName("block")]
		public Tip Block { get; set; }
	}
}
