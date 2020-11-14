using Cardano.Core.Http;
using Cardano.Core.Http.Requests.Interfaces;
using Cardano.Core.Models.Common;
using Cardano.Wallet.Rest.Api.Common;
using Cardano.Wallet.Rest.Api.Interfaces.ShelleySequential;
using Cardano.Wallet.Rest.Api.Models.Byron.Migration;
using Cardano.Wallet.Rest.Api.Models.Transaction;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cardano.Wallet.Rest.Api.Implementation.ShelleySequential
{
    internal class MigrationRequests : IMigrationRequests
    {
        private readonly IGetRequests getRequests;
        private readonly IPostRequests postRequests;

        public MigrationRequests(IGetRequests getRequests,
            IPostRequests postRequests)
        {
            this.getRequests = getRequests;
            this.postRequests = postRequests;
        }

        public async Task<Response<IEnumerable<Transaction>>> MigrateAsync(
            string walletId,
            MigrationData migrationData)
        {
            var path = HttpHelper.UrlCombine(
                PathConstants.Wallets,
                walletId,
                PathConstants.Migrations);

            return await postRequests.PostAsync<IEnumerable<Transaction>, MigrationData>(path, migrationData);
        }

        public async Task<Response<MigrationFullCost>> GetCostAsync(
            string walletId)
        {
            var path = HttpHelper.UrlCombine(
                PathConstants.Wallets,
                walletId,
                PathConstants.Migrations);

            return await getRequests.GetAsync<MigrationFullCost>(path);
        }
    }
}
