using Cardano.Wallet.Rest.Api.Common;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cardano.Wallet.Rest.Api.Interfaces.ByronRandom;
using Cardano.Wallet.Rest.Api.Models.Byron.Wallet;
using Cardano.Wallet.Rest.Api.Models.Wallet;
using Cardano.Core.Models.Common;
using Cardano.Core.Http;
using Cardano.Core.Http.Requests.Interfaces;

namespace Cardano.Wallet.Rest.Api.Implementation.ByronRandom
{
    internal class ByronWalletRequests : IByronWalletRequests
    {
        private readonly IGetRequests getRequests;
        private readonly IPostRequests postRequests;
        private readonly IPutRequests putRequests;
        private readonly IDeleteRequests deleteRequests;

        public ByronWalletRequests(IGetRequests getRequests,
            IPostRequests postRequests,
            IPutRequests putRequests,
            IDeleteRequests deleteRequests)
        {
            this.getRequests = getRequests;
            this.postRequests = postRequests;
            this.putRequests = putRequests;
            this.deleteRequests = deleteRequests;
        }

        public async Task<Response<ByronWalletModel>> RestoreAsync<TModel>(
            TModel walletRestoreModel)
            where TModel : ByronWalletMetadata
        {
            var path = HttpHelper.UrlCombine(PathConstants.ByronWallets);

            return await postRequests.PostAsync<ByronWalletModel, TModel>(path, walletRestoreModel);
        }

        public async Task<Response<IEnumerable<ByronWalletModel>>> GetListAsync()
        {
            var path = HttpHelper.UrlCombine(PathConstants.ByronWallets);

            return await getRequests.GetAsync<IEnumerable<ByronWalletModel>>(path);
        }

        public async Task<Response<UTxOStatistics>> GetUTxOStatisticsAsync(
            string walletId)
        {
            var path = HttpHelper.UrlCombine(
                PathConstants.ByronWallets,
                walletId,
                PathConstants.Statistics,
                PathConstants.Utxos);

            return await getRequests.GetAsync<UTxOStatistics>(path);
        }

        public async Task<Response<ByronWalletModel>> GetByIdAsync(
            string walletId)
        {
            var path = HttpHelper.UrlCombine(
                PathConstants.ByronWallets,
                walletId);

            return await getRequests.GetAsync<ByronWalletModel>(path);
        }

        public async Task<Response> DeleteAsync(
            string walletId)
        {
            var path = HttpHelper.UrlCombine(
                PathConstants.ByronWallets,
                walletId);

            return await deleteRequests.DeleteAsync(path);
        }

        public async Task<Response<ByronWalletModel>> UpdateMetadataAsync(
            string walletId,
            ByronWalletMetadata data)
        {
            var path = HttpHelper.UrlCombine(
                PathConstants.ByronWallets, 
                walletId);

            return await putRequests.PutAsync<ByronWalletModel, ByronWalletMetadata>(path, data);
        }

        public async Task<Response> UpdatePassphraseAsync(
            string walletId,
            PassphraseUpdateResponse data)
        {
            var path = HttpHelper.UrlCombine(
                PathConstants.ByronWallets,
                walletId,
                PathConstants.Passphrase);

            return await putRequests.PutAsync(path, data);
        }
    }
}
