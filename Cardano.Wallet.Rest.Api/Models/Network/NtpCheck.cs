using System.Text.Json.Serialization;

namespace Cardano.Wallet.Rest.Api.Models.Network
{
	public class NtpCheck
	{
		/// <summary>
		/// Enum: "available" "unavailable" "pending"
		/// </summary>
		[JsonPropertyName("status")]
		public string Status { get; set; }

		/// <summary>
		/// Drift offset of the local clock.
		/// </summary>
		[JsonPropertyName("offset")]
		public Offset Offset { get; set; }
	}
}
