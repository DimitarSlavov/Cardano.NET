using System.Text.Json.Serialization;

namespace Cardano.Core.Models.Common
{
	public class CardanoHttpResponseModel
	{
		[JsonPropertyName("message")]
		public string Message { get; set; }

		[JsonPropertyName("code")]
		public string Code { get; set; }
	}
}
