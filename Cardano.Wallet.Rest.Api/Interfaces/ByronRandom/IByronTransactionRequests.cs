using Cardano.Core.Nomenclatures;
using Cardano.Core.Models.Common;
using Cardano.Wallet.Rest.Api.Models.Common;
using Cardano.Wallet.Rest.Api.Models.Transaction;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Transaction = Cardano.Wallet.Rest.Api.Models.Transaction.Transaction;

namespace Cardano.Wallet.Rest.Api.Interfaces.ByronRandom
{
    public interface IByronTransactionRequests
    {
		/// <summary>
		/// Estimate fee for the transaction.
		/// </summary>
		/// <returns>
		/// 200 Ok,
		/// 400 Bad Request,
		/// 403 Forbidden,
		/// 404 Not Found,
		/// 405 Method Not Allowed,
		/// 406 Not Acceptable,
		/// 415 Unsupported Media Type
		/// </returns>
		Task<Response<EstimatedFee>> EstimateFeeAsync(string walletId, RandomSelection data);

		/// <summary>
		/// Create and send transaction from the wallet.
		/// </summary>
		/// <returns>
		/// 202 Accepted,
		/// 400 Bad Request,
		/// 403 Forbidden,
		/// 404 Not Found,
		/// 405 Method Not Allowed,
		/// 406 Not Acceptable,
		/// 415 Unsupported Media Type
		/// </returns>
		Task<Response<Transaction>> CreateAsync(string walletId, TransactionCreationArguments data);

		/// <summary>
		/// Lists all incoming and outgoing wallet's transactions.
		/// </summary>
		/// <returns>
		/// 200 Ok,
		/// 404 Not Found,
		/// 405 Method Not Allowed,
		/// 406 Not Acceptable
		/// </returns>
		Task<Response<IEnumerable<Transaction>>> GetListAsync(string walletId, DateTime? start = null, DateTime? end = null, OrderEnum order = null);

		/// <summary>
		/// Get transaction by id.
		/// </summary>
		/// <returns>
		/// 200 Ok,
		/// 404 Not Found,
		/// 405 Method Not Allowed,
		/// 406 Not Acceptable
		/// </returns>
		Task<Response<Transaction>> GetByIdAsync(string walletId, string transactionId);

		/// <summary>
		/// Forget pending transaction. Importantly, a transaction, when sent, cannot be cancelled. One can only request forgetting about it in order to try spending (concurrently) the same UTxO in another transaction. But, the transaction may still show up later in a block and therefore, appear in the wallet.
		/// </summary>
		/// <returns>
		/// 204 No Content,
		/// 400 Bad Request,
		/// 403 Forbidden,
		/// 404 Not Found,
		/// 405 Method Not Allowed,
		/// 406 Not Acceptable,
		/// 415 Unsupported Media Type
		/// </returns>
		Task<Response> ForgetAsync(string walletId, string transactionId);
	}
}
