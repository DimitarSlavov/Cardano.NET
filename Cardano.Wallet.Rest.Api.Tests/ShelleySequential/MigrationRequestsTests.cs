using Cardano.Wallet.Rest.Api.Interfaces.ShelleySequential;
using Cardano.Wallet.Rest.Api.Models.Byron.Migration;
using Cardano.Wallet.Rest.Api.Tests.Helpers;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace Cardano.Wallet.Rest.Api.Tests.ShelleySequential
{
    [TestFixture]
    internal class MigrationRequestsTests : ShellyCardanoWalletTestsBase
    {
        private async Task AssertBalanceTransfered(string walletId)
        {
            while (true)
            {
                await SleepAsync(3000);

                var wallet = await GetWalletByIdAsync(walletId);

                Assert.NotNull(wallet.Content);

                var balance = wallet.Content.Balance.Available.Quantity;

                if (balance != default)
                {
                    break;
                }
            }
        }

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

        [Test]
        public async Task TestMigrateAsync()
        {
            var addressTo = string.Empty;
            var walletIdFrom = string.Empty;

            var wallets = await GetWalletListAsync();

            Assert.NotNull(wallets.Content);

            var wallet = wallets.Content.First(e => e.Name == ShellyWalletHelper.WalletTest2.Name);

            var walletId = wallet.Id;

            var addresses = await GetAddressListAsync(walletId);

            Assert.NotNull(addresses.Content);

            var address = addresses.Content.First().Id;

            var transaction = await CreateTransactionAsync(address);

            Assert.NotNull(transaction.Content);

            await AssertBalanceTransfered(walletId);
      
            var addressList = await GetAddressListAsync(ShellyWalletModel.Id);

            Assert.NotNull(addressList.Content);

            addressTo = addressList.Content.First().Id;
            walletIdFrom = walletId;

            var migrationData = new MigrationData
            {
                Addresses = new string[]
                {
                    addressTo
                },
                Passphrase = ShellyWalletHelper.Passphrase
            };

            var result = await GetCardanoWalletService<IMigrationRequests>()
                .MigrateAsync(
                    walletIdFrom,
                    migrationData);

            Assert.NotNull(result.Content);
        }

        [Test]
        public async Task TestGetCostAsync()
        {
            var result = await GetCardanoWalletService<IMigrationRequests>()
                .GetCostAsync(ShellyWalletModel.Id);

            Assert.NotNull(result.Content);
        }
    }
}
