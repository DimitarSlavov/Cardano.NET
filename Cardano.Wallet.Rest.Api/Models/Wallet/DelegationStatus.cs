using Cardano.Core.Nomenclatures;
using System.Text.Json.Serialization;

namespace Cardano.Wallet.Rest.Api.Models.Wallet
{
	public class DelegationStatus
	{
		private DelegationStatusEnum status;

		/// <summary>
		/// Enum: "not_delegating" "delegating"
		/// </summary>
		[JsonPropertyName("status")]
		public string Status
		{
			get => status.GetValue();
			set
			{
				if (DelegationStatusEnum.Delegating.GetValue().Equals(value))
				{
					status = DelegationStatusEnum.Delegating;
				}
				else if (DelegationStatusEnum.NotDelegating.GetValue().Equals(value))
				{
					status = DelegationStatusEnum.NotDelegating;
				}
			}
		}

		/// <summary>
		/// A unique Stake-Pool identifier (present only if status = delegating)
		/// </summary>
		[JsonPropertyName("target")]
		public string Target { get; set; }
	}
}
