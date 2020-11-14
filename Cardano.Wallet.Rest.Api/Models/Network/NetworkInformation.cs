using Cardano.Wallet.Rest.Api.Models.Common;
using System.Text.Json.Serialization;

namespace Cardano.Wallet.Rest.Api.Models.Network
{
	public class NetworkInformation
	{
		/// <summary>
		/// Estimated synchronization progress of the node with the underlying network. Note that this may change quite arbitrarily as the node may switch to shorter or longer chain forks.
		/// </summary>
		[JsonPropertyName("sync_progress")]
		public State SyncProgress { get; set; }

		/// <summary>
		/// Underlying node's tip
		/// </summary>
		[JsonPropertyName("node_tip")]
		public Tip NodeTip { get; set; }

		/// <summary>
		/// A network tip
		/// </summary>
		[JsonPropertyName("network_tip")]
		public Block NetworkTip { get; set; }

		[JsonPropertyName("next_epoch")]
		public ChangesAt NextEpoch { get; set; }
	}
}
