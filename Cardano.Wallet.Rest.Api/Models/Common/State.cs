using Cardano.Core.Nomenclatures;
using System.Text.Json.Serialization;

namespace Cardano.Wallet.Rest.Api.Models.Common
{
	public class State
	{
        private WalletStatusEnum status;

		/// <summary>
		/// Enum: "ready" "syncing" "not_responding"
		/// </summary>
		[JsonPropertyName("status")]
		public string Status
        {
            get => status.GetValue();
            set
            {
                if (WalletStatusEnum.Ready.GetValue().Equals(value))
                {
                    status = WalletStatusEnum.Ready;
                }
                else if (WalletStatusEnum.Syncing.GetValue().Equals(value))
                {
                    status = WalletStatusEnum.Syncing;
                }
                else if (WalletStatusEnum.NotResponding.GetValue().Equals(value))
                {
                    status = WalletStatusEnum.NotResponding;
                }
            }
        }

        [JsonPropertyName("progress")]
		public Progress Progress { get; set; }
	}
}
