using Cardano.Wallet.Rest.Api.Models.Common;
using System.Text.Json.Serialization;

namespace Cardano.Wallet.Rest.Api.Models.StakePool
{
	//TODO: to add the other stake pool model
	public abstract class StakePoolBase
	{
		/// <summary>
		/// A unique identifier for the pool.
		/// </summary>
		[JsonPropertyName("id")]
		public string Id { get; set; }

		/// <summary>
		/// Estimated cost set by the pool operator when registering his pool. This fixed cost is taken from each reward earned by the pool before splitting rewards between stakeholders.
		/// </summary>
		[JsonPropertyName("cost")]
		public Fund Cost { get; set; }

		/// <summary>
		/// Variable margin on the total reward given to an operator before splitting rewards between stakeholders.
		/// </summary>
		[JsonPropertyName("margin")]
		public Progress Margin { get; set; }
	}
}
