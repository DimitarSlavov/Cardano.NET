using Cardano.Wallet.Rest.Api.Interfaces.ShelleySequential;
using Cardano.Core.Models.Common;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cardano.Core.Http;
using Cardano.Wallet.Rest.Api.Models.StakePool;
using Cardano.Wallet.Rest.Api.Models.Common;
using Cardano.Wallet.Rest.Api.Common;
using Cardano.Wallet.Rest.Api.Models.Transaction;
using Cardano.Core.Http.Requests.Interfaces;

namespace Cardano.Wallet.Rest.Api.Implementation.ShelleySequential
{
	internal class StakePoolRequests : IStakePoolRequests
	{
		private readonly IGetRequests getRequests;
		private readonly IPutRequests putRequests;
		private readonly IDeleteRequests deleteRequests;

		public StakePoolRequests(IGetRequests getRequests,
			IPutRequests putRequests,
			IDeleteRequests deleteRequests)
		{
			this.getRequests = getRequests;
			this.putRequests = putRequests;
			this.deleteRequests = deleteRequests;
		}

		public async Task<Response<IEnumerable<TStakePoolModel>>> GetAllAsync<TStakePoolModel>(
			long stake)
			where TStakePoolModel : StakePoolBase
		{
			var path = PathConstants.StakePools.AppendQuery(nameof(stake), stake);

			return await getRequests.GetAsync<IEnumerable<TStakePoolModel>>(path);
		}

		public async Task<Response<EstimatedFee>> GetEstimateFeeAsync(
			string walletId)
		{
			var path = HttpHelper.UrlCombine(
				PathConstants.Wallets,
				walletId,
				PathConstants.DelegationFees);

			return await getRequests.GetAsync<EstimatedFee>(path);
		}

		public async Task<Response<Transaction>> JoinOneAsync(
			string walletId,
			string stakePoolId,
			WalletPassphrase data)
		{
			var path = HttpHelper.UrlCombine(
				PathConstants.StakePools,
				stakePoolId,
				PathConstants.Wallets,
				walletId);

			return await putRequests.PutAsync<Transaction, WalletPassphrase>(path, data);
		}

		public async Task<Response<Transaction>> QuitDelegatingAsync(
			string walletId,
			WalletPassphrase data)
		{
			var path = HttpHelper.UrlCombine(
				PathConstants.StakePools,
				PathConstants.Asterisk,
				PathConstants.Wallets,
				walletId);

			return await deleteRequests.DeleteAsync<Transaction, WalletPassphrase>(path, data);
		}
	}
}
