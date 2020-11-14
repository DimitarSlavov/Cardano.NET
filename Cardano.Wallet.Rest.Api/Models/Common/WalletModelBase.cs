using Cardano.Wallet.Rest.Api.Common;
using System.Text.Json.Serialization;

namespace Cardano.Wallet.Rest.Api.Models.Common
{
	public abstract class WalletModelBase : WalletMetadata
	{
		/// <summary>
		/// Number of consecutive unused addresses allowed
		/// </summary>
		[JsonPropertyName("address_pool_gap")]
		public virtual byte AddressPoolGap { get; set; } = DefaultValueConstants.AddressPoolGap;
	}
}
