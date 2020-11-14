using Cardano.Wallet.Rest.Api.Models.Common;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Cardano.Wallet.Rest.Api.Models.Transaction
{
	public class Transaction : CurrencyAmount
	{
		/// <summary>
		/// A unique identifier for this transaction
		/// </summary>
		[JsonPropertyName("id")]
		public string Id { get; set; }

		/// <summary>
		/// Absolute time at which the transaction was inserted in a block.
		/// </summary>
		[JsonPropertyName("inserted_at")]
		public Inserted InsertedAt { get; set; }

		/// <summary>
		/// The point in time at which a transaction became pending.
		/// </summary>
		[JsonPropertyName("pending_since")]
		public Inserted PendingSince { get; set; }

		/// <summary>
		/// Current depth of the transaction in the local chain.
		/// </summary>
		[JsonPropertyName("depth")]
		public BlockHeight Depth { get; set; }

		/// <summary>
		/// Enum: "outgoing" "incoming"
		/// </summary>
		[JsonPropertyName("direction")]
		public string Direction { get; set; }

		/// <summary>
		/// A list of transaction inputs
		/// </summary>
		[JsonPropertyName("inputs")]
		public IEnumerable<Input> Inputs { get; set; }

		/// <summary>
		/// A list of transaction inputs
		/// </summary>
		[JsonPropertyName("outputs")]
		public IEnumerable<Output> Outputs { get; set; }

		/// <summary>
		/// Enum: "pending" "in_ledger". Current transaction status.
		/// </summary>
		[JsonPropertyName("status")]
		public string Status { get; set; }
	}
}
