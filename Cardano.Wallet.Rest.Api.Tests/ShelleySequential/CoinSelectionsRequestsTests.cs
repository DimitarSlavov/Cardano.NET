using Cardano.Core.Nomenclatures;
using Cardano.Wallet.Rest.Api.Interfaces.ShelleySequential;
using Cardano.Wallet.Rest.Api.Models.Common;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace Cardano.Wallet.Rest.Api.Tests.ShelleySequential
{
    [TestFixture]
    internal class CoinSelectionsRequestsTests : ShellyCardanoWalletTestsBase
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

        [Test]
        public async Task TestSelectCoins()
        {
            var wallets = await GetWalletListAsync();

            Assert.NotNull(wallets.Content);

            var icarusWalletId = wallets.Content.First(w => w.Name == Helpers.ShellyWalletHelper.WalletIcarus.Name).Id;

            Assert.NotNull(icarusWalletId);

            var xpubWalletId = wallets.Content.First(w => w.Name == Helpers.ShellyWalletHelper.NonRandomWalletFromXpub.Name).Id;

            Assert.NotNull(xpubWalletId);

            var addresses = await GetAddressListAsync(xpubWalletId);

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

            var result = await GetCardanoWalletService<ICoinSelectionRequests>()
                .SelectCoins(
                    icarusWalletId,
                    randomSelection);

            Assert.NotNull(result.Content);
        }
    }
}
