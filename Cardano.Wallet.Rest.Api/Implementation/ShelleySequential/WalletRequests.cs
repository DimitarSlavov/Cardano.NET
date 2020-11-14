using Cardano.Wallet.Rest.Api.Interfaces.ShelleySequential;
using Cardano.Core.Models.Common;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cardano.Core.Http;
using Cardano.Wallet.Rest.Api.Models.Wallet;
using Cardano.Wallet.Rest.Api.Models.Common;
using Cardano.Wallet.Rest.Api.Common;
using Cardano.Wallet.Rest.Api.Models.Shelly;
using Cardano.Core.Http.Requests.Interfaces;

namespace Cardano.Wallet.Rest.Api.Implementation.ShelleySequential
{
	internal class WalletRequests : IWalletRequests
	{
		private readonly IGetRequests getRequests;
		private readonly IPostRequests postRequests;
		private readonly IPutRequests putRequests;
		private readonly IDeleteRequests deleteRequests;

		public WalletRequests(IGetRequests getRequests,
			IPostRequests postRequests,
			IPutRequests putRequests,
			IDeleteRequests deleteRequests)
		{
			this.getRequests = getRequests;
			this.postRequests = postRequests;
			this.putRequests = putRequests;
			this.deleteRequests = deleteRequests;
		}

		public async Task<Response<ShellyWalletModel>> CreateOrRestoreAsync<D>(
			D data)
			where D : WalletModelBase
		{
			var path = HttpHelper.UrlCombine(PathConstants.Wallets);

			return await postRequests.PostAsync<ShellyWalletModel, D>(path, data);
		}

		public async Task<Response<IEnumerable<ShellyWalletModel>>> GetListAsync()
        {
			var path = HttpHelper.UrlCombine(PathConstants.Wallets);

			return await getRequests.GetAsync<IEnumerable<ShellyWalletModel>>(path);
		}


		public async Task<Response<UTxOStatistics>> GetUTxOStatisticsAsync(
			string walletId)
		{
			var path = HttpHelper.UrlCombine(
				PathConstants.Wallets,
				walletId,
				PathConstants.Statistics,
				PathConstants.Utxos);

			return await getRequests.GetAsync<UTxOStatistics>(path);
		}

		public async Task<Response<ShellyWalletModel>> GetByIdAsync(
			string walletId)
        {
			var path = HttpHelper.UrlCombine(
				PathConstants.Wallets, 
				walletId);

			return await getRequests.GetAsync<ShellyWalletModel>(path);
		}

		public async Task<Response> DeleteAsync(
			string walletId)
        {
			var path = HttpHelper.UrlCombine(
				PathConstants.Wallets, 
				walletId);

			return await deleteRequests.DeleteAsync(path);
		}

		public async Task<Response<ShellyWalletModel>> UpdateMetadataAsync(
			string walletId,
			WalletMetadata data)
		{
			var path = HttpHelper.UrlCombine(
				PathConstants.Wallets,
				walletId);

			return await putRequests.PutAsync<ShellyWalletModel, WalletMetadata>(path, data);
		}

		public async Task<Response> UpdatePassphraseAsync(
			string walletId,
			PassphraseUpdateResponse data)
        {
			var path = HttpHelper.UrlCombine(
				PathConstants.Wallets, 
				walletId, 
				PathConstants.Passphrase);

			return await putRequests.PutAsync(path, data);
		}
	}
}
