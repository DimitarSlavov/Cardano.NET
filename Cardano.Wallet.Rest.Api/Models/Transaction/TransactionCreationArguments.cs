using Cardano.Wallet.Rest.Api.Models.Common;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Cardano.Wallet.Rest.Api.Models.Transaction
{
	public class TransactionCreationArguments
	{
		/// <summary>
		/// A list of target outputs
		/// </summary>
		[JsonPropertyName("payments")]
		public IEnumerable<Payment> Payments { get; set; }

		/// <summary>
		/// The wallet's master passphrase.
		/// </summary>
		[JsonPropertyName("passphrase")]
		public string Passphrase { get; set; }
	}
}
