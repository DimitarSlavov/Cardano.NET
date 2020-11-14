using Cardano.Core.Nomenclatures;
using System.Text.Json.Serialization;

namespace Cardano.Wallet.Rest.Api.Models.Address
{
	public class Address
	{
        private AddressStateEnum state;

        [JsonPropertyName("id")]
		public string Id { get; set; }

		/// <summary>
		/// An optional filter on the address state.
		/// </summary>
		[JsonPropertyName("state")]
		public string State
        {
            get => state.GetValue();
            set
            {
                if (AddressStateEnum.Used.GetValue().Equals(value))
                {
                    state = AddressStateEnum.Used;
                }
                else if (AddressStateEnum.Unused.GetValue().Equals(value))
                {
                    state = AddressStateEnum.Unused;
                }
            }
        }
    }
}
