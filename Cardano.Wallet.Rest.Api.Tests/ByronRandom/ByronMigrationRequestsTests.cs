using Cardano.Wallet.Rest.Api.Interfaces.ByronRandom;
using Cardano.Wallet.Rest.Api.Models.Byron.Migration;
using Cardano.Wallet.Rest.Api.Tests.Helpers;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace Cardano.Wallet.Rest.Api.Tests.ByronRandom
{
    [TestFixture]
    internal class ByronMigrationRequestsTests : ByronCardanoWalletTestsBase
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
            await RemoveTestWallet();

            await SleepAsync();

            var result = await CreateTestWalletAsync();

            ByronWalletModel = result;

            var addresses = await GetAddressListAsync(result.Id);

            if (!addresses.Content.Any())
            {
                await CreateAddressAsync();
            }
        }

        [OneTimeTearDown]
        public async Task OneTimeTearDown() => await OneTimeTearDownBase();

        [Test]
        public async Task TestMigrateAsync()
        {
            var addressTo = string.Empty;
            var walletIdFrom = string.Empty;

            var icarusWalletId = await GetIcarusWalletIdAsync();

            Assert.NotNull(icarusWalletId);

            var icarusWallet = await GetWalletByIdAsync(icarusWalletId);

            Assert.NotNull(icarusWallet.Content);

            var icarusWalletAddress = await GetUsedAddressForIcarusWalletAsync();

            Assert.NotNull(icarusWalletAddress);

            var icarusTransaction = await CreateTransactionAsync(icarusWalletAddress);

            await AssertBalanceTransfered(icarusWalletId);

            Assert.NotNull(icarusTransaction.Content);

            var randomStyleAddress = await GetAddressListAsync(ByronWalletModel.Id);

            Assert.NotNull(randomStyleAddress.Content.First());

            addressTo = randomStyleAddress.Content.First().Id;
            walletIdFrom = icarusWalletId;

            var migrationData = new MigrationData
            {
                Addresses = new string[]
                {
                    addressTo
                },
                Passphrase = ByronWalletHelper.Passphrase
            };

            var result = await GetCardanoWalletService<IByronMigrationRequests>()
                .MigrateAsync(
                    walletIdFrom,
                    migrationData);
            
            Assert.NotNull(result.Content);
        }

        [Test]
        public async Task TestGetCostAsync()
        {
            var result = await GetCardanoWalletService<IByronMigrationRequests>()
                .GetCostAsync(ByronWalletModel.Id);

            Assert.NotNull(result.Content);
        }
    }
}
