using System.Text.Json.Serialization;

namespace Cardano.Wallet.Rest.Api.Models.StakePool
{
	public class JormungandrMetadata : MetadataBase
	{
		[JsonPropertyName("owner")]
		public string Owner { get; set; }

		[JsonPropertyName("pledge_address")]
		public string PledgeAddress { get; set; }
	}
}
