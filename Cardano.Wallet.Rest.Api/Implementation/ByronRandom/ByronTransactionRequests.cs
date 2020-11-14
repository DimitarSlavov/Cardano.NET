using Cardano.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cardano.Core.Http;
using Cardano.Wallet.Rest.Api.Models.Transaction;
using Cardano.Wallet.Rest.Api.Models.Common;
using Cardano.Wallet.Rest.Api.Common;
using Cardano.Core.Nomenclatures;
using Cardano.Wallet.Rest.Api.Interfaces.ByronRandom;
using Cardano.Core.Http.Requests.Interfaces;
using System.Net;

namespace Cardano.Wallet.Rest.Api.Implementation.ByronRandom
{
    internal class ByronTransactionRequests : IByronTransactionRequests
	{
		private readonly IGetRequests getRequests;
		private readonly IPostRequests postRequests;
		private readonly IDeleteRequests deleteRequests;

		public ByronTransactionRequests(IGetRequests getRequests,
			IPostRequests postRequests,
			IDeleteRequests deleteRequests)
		{
			this.getRequests = getRequests;
			this.postRequests = postRequests;
			this.deleteRequests = deleteRequests;
		}

		public async Task<Response<EstimatedFee>> EstimateFeeAsync(
			string walletId,
			RandomSelection data)
		{
			var path = HttpHelper.UrlCombine(
				PathConstants.ByronWallets,
				walletId,
				PathConstants.PaymentFees);

			return await postRequests.PostAsync<EstimatedFee, RandomSelection>(path, data);
		}

		public async Task<Response<Transaction>> CreateAsync(
			string walletId,
			TransactionCreationArguments data)
		{
			var path = HttpHelper.UrlCombine(
				PathConstants.ByronWallets,
				walletId,
				PathConstants.Transactions);

			return await postRequests.PostAsync<Transaction, TransactionCreationArguments>(path, data);
		}

		public async Task<Response<IEnumerable<Transaction>>> GetListAsync(
			string walletId,
			DateTime? start = null,
			DateTime? end = null,
			OrderEnum order = null)
		{
			if (order == null)
			{
				order = OrderEnum.Descending;
			}

			var pathBase = HttpHelper.UrlCombine(
				PathConstants.ByronWallets,
				walletId,
				PathConstants.Transactions);

			if (start != null)
			{
				pathBase.AppendQuery(nameof(start), start);
			}

			if (end != null)
			{
				if (start != null
					&& start > end)
				{
					var error = Response<IEnumerable<Transaction>>.GetResponse(ErrorMessages.StartEndDateTime, HttpStatusCode.BadRequest);

					return error;
				}

				pathBase.AppendQuery(nameof(end), end);
			}

			pathBase.AppendQuery(nameof(order), order.GetValue());

			return await getRequests.GetAsync<IEnumerable<Transaction>>(pathBase);
		}

		public async Task<Response<Transaction>> GetByIdAsync(
			string walletId,
			string transactionId)
		{
			var pathBase = HttpHelper.UrlCombine(
				PathConstants.ByronWallets,
				walletId,
				PathConstants.Transactions,
				transactionId);

			return await getRequests.GetAsync<Transaction>(pathBase);
		}

		public async Task<Response> ForgetAsync(
			string walletId,
			string transactionId)
		{
			var path = HttpHelper.UrlCombine(
				PathConstants.ByronWallets,
				walletId,
				PathConstants.Transactions,
				transactionId);

			return await deleteRequests.DeleteAsync(path);
		}
	}
}
