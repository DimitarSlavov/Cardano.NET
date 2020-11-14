using System.Text.Json.Serialization;

namespace Cardano.Wallet.Rest.Api.Models.Common
{
	public class Tip : Block
	{
		[JsonPropertyName("height")]
		public BlockHeight Height { get; set; }
	}
}
