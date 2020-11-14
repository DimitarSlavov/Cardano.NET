using Cardano.Wallet.Rest.Api.Interfaces.ShelleySequential;
using Cardano.Wallet.Rest.Api.Models.StakePool;
using Cardano.Wallet.Rest.Api.Tests.Helpers;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace Cardano.Wallet.Rest.Api.Tests.ShelleySequential
{
    [TestFixture]
    internal class StakePoolRequestsTests : ShellyCardanoWalletTestsBase
    {
        [OneTimeSetUp]
        public async Task SetUp()
        {
            await RemoveWallet();

            await SleepAsync();

            var result = await CreateTestWalletAsync();

            ShellyWalletModel = result;
        }

        [OneTimeTearDown]
        public async Task OneTimeTearDown() => await OneTimeTearDownBase();

        [Test, Order(1)]
        public async Task TestGetAllAsync()
        {
            var result = await GetCardanoWalletService<IStakePoolRequests>()
                .GetAllAsync<CardanoNodeStakePool>(100000);

            Assert.NotNull(result.Content);
        }

        [Test, Order(2)]
        public async Task TestGetEstimateFeeAsync()
        {
            var result = await GetCardanoWalletService<IStakePoolRequests>()
               .GetEstimateFeeAsync(ShellyWalletModel.Id);

            Assert.NotNull(result.Content);
        }

        [Test, Order(4)]
        public async Task TestQuitDelegatingAsync()
        {
            var walletPassphrase = new WalletPassphrase
            {
                Passphrase = ShellyWalletHelper.Passphrase
            };

            var result = await GetCardanoWalletService<IStakePoolRequests>()
             .QuitDelegatingAsync(
                ShellyWalletModel.Id, 
                walletPassphrase);

            Assert.NotNull(result.Content);
        }

        [Test, Order(3)]
        public async Task TestJoinOneAsync()
        {
            var stakePools = await GetCardanoWalletService<IStakePoolRequests>()
               .GetAllAsync<CardanoNodeStakePool>(100000);

            Assert.NotNull(stakePools.Content);

            var stakePoolId = stakePools.Content.First().Id;
            var walletPassphrase = new WalletPassphrase
            {
                Passphrase = ShellyWalletHelper.Passphrase
            };

            var result = await GetCardanoWalletService<IStakePoolRequests>()
               .JoinOneAsync(
                    ShellyWalletModel.Id, 
                    stakePoolId,
                    walletPassphrase);

            Assert.NotNull(result.Content);
        }
    }
}
