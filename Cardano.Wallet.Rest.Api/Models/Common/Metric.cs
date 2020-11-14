namespace Cardano.Wallet.Rest.Api.Models.Common
{
	public abstract class Metric<T>
	{
		public virtual T Quantity { get; set; }

		public virtual string Unit { get; set; }
	}
}
