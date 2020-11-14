using Cardano.Core.Http;
using Cardano.Core.Http.Requests.Interfaces;
using Cardano.Core.Models.Common;
using Cardano.Wallet.Rest.Api.Common;
using Cardano.Wallet.Rest.Api.Interfaces.ByronRandom;
using Cardano.Wallet.Rest.Api.Models.CoinSelections;
using Cardano.Wallet.Rest.Api.Models.Common;
using System.Threading.Tasks;

namespace Cardano.Wallet.Rest.Api.Implementation.ByronRandom
{
    internal class ByronCoinSelectionRequests : IByronCoinSelectionRequests
    {
        private readonly IPostRequests postRequests;

        public ByronCoinSelectionRequests(IPostRequests postRequests)
        {
            this.postRequests = postRequests;
        }

        public async Task<Response<TransactionFlow>> SelectCoinsAsync(
            string walletId,
            RandomSelection payments)
        {
            var path = HttpHelper.UrlCombine(
                PathConstants.ByronWallets,
                walletId,
                PathConstants.CoinSelections,
                PathConstants.Random);

            return await postRequests.PostAsync<TransactionFlow, RandomSelection>(path, payments);
        }
    }
}
