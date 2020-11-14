using Cardano.Core.Nomenclatures;
using Cardano.Wallet.Rest.Api.Interfaces.ByronRandom;
using Cardano.Wallet.Rest.Api.Models.Common;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace Cardano.Wallet.Rest.Api.Tests.ByronRandom
{
    [TestFixture]
    internal class ByronCoinSelectionRequestsTests : ByronCardanoWalletTestsBase
    {
        [OneTimeSetUp]
        public async Task SetUp()
        {
            await RemoveTestWallet();

            await SleepAsync();

            var result = await CreateTestWalletAsync();

            ByronWalletModel = result;
        }

        [OneTimeTearDown]
        public async Task OneTimeTearDown() => await OneTimeTearDownBase();

        [Test]
        public async Task TestSelectCoins()
        {
            var wallets = await GetWalletListAsync();

            Assert.NotNull(wallets.Content);

            var icarusWalletId = wallets.Content.First(w => w.Name == Helpers.ByronWalletHelper.WalletStyleIcarus.Name).Id;

            Assert.NotNull(icarusWalletId);

            var ledgerWalletId = wallets.Content.First(w => w.Name == Helpers.ByronWalletHelper.WalletStyleLedger.Name).Id;

            Assert.NotNull(ledgerWalletId);

            var addresses = await GetAddressListAsync(ledgerWalletId);

            var address = addresses.Content.First(a => a.State == AddressStateEnum.Used.GetValue());

            Assert.NotNull(address);

            var randomSelection = new RandomSelection
            {
                Payments = new Payment[]
                {
                    new Payment
                    {
                        Address = address.Id,
                        Amount = new Fund
                        {
                            Quantity = DefaultQuantity
                        }
                    }
                }
            };

            var result = await GetCardanoWalletService<IByronCoinSelectionRequests>()
                .SelectCoinsAsync(
                    icarusWalletId, 
                    randomSelection);

            Assert.NotNull(result.Content);
        }
    }
}
