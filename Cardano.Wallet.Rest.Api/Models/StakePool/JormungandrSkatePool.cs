using System.Text.Json.Serialization;

namespace Cardano.Wallet.Rest.Api.Models.StakePool
{
    public class JormungandrSkatePool : StakePoolBase
    {
		[JsonPropertyName("metrics")]
		public JormungandrMetric Metrics { get; set; }

		/// <summary>
		/// Apparent performance of the stake pool over past epochs. This indicator is computed using data available to the server. In particular, the server can't reliably know the stake distribution of past epochs without being during those epochs. The performance are therefore an average measure that is more accurate for servers that are online often. The performance is a float with double-precision which is typically within 0 and 1:
		/// 0 means that a pool is not performing well.
		/// 1 means that a pool is performing as expected.
		/// above 1 means the pool is performing beyond expectations.
		/// Pools that are lucky enough to win most of their slots early in the epoch will tend to look like they're over-performing for a while. Having a wallet regularly connected to the network would harmonize the performance and give better results.
		/// </summary>
		[JsonPropertyName("apparent_performance")]
		public float ApparentPerformance { get; set; }

		/// <summary>
		/// Information about the stake pool.
		/// </summary>
		[JsonPropertyName("metadata")]
		public JormungandrMetadata Metadata { get; set; }

		/// <summary>
		/// Saturation-level of the pool based on the desired number of pools aimed by the network. A value above 1 indicates that the pool is saturated.
		/// </summary>
		[JsonPropertyName("saturation")]
		public float Saturation { get; set; }

		/// <summary>
		/// How desirable / attractive a pool is. To determine a pool's rank, we order pools by decreasing desirability. The most desirable pool gets rank 1, the second most desirable pool gets rank 2 and so on.
		/// </summary>
		[JsonPropertyName("desirability")]
		public float Desirability { get; set; }
	}
}
