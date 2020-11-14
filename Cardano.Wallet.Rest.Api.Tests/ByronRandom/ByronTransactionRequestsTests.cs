using Cardano.Wallet.Rest.Api.Interfaces.ByronRandom;
using Cardano.Wallet.Rest.Api.Models.Common;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace Cardano.Wallet.Rest.Api.Tests.ByronRandom
{
    [TestFixture]
    internal class ByronTransactionRequestsTests : ByronCardanoWalletTestsBase
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
        public async Task TestGetTransactionListAsync()
        {
            var result = await GetCardanoWalletService<IByronTransactionRequests>()
                .GetListAsync(ByronWalletModel.Id);

            Assert.True(result.Content.Any());
        }

        [Test]
        public async Task TestCreateTransactionAsync()
        {
            var address = await GetUsedAddressForIcarusWalletAsync();
            var result = await CreateTransactionAsync(address);

            Assert.NotNull(result.Content);
        }

        [Test]
        public async Task TestEstimateFeeAsync()
        {
            var address = await GetUsedAddressForIcarusWalletAsync();

            var randomSelection = new RandomSelection
            {
                Payments = new Payment[]
                {
                    new Payment
                    {
                        Address = address,
                        Amount = new Fund
                        {
                            Quantity = DefaultQuantity
                        }
                    }
                }
            };

            var result = await GetCardanoWalletService<IByronTransactionRequests>()
                .EstimateFeeAsync(
                    ByronWalletModel.Id,
                    randomSelection);

            Assert.NotNull(result.Content);
        }

        [Test]
        public async Task TestForgetAsync()
        {
            var address = await GetUsedAddressForIcarusWalletAsync();
            var transaction = await CreateTransactionAsync(address);

            Assert.NotNull(transaction.Content);

            var result = await GetCardanoWalletService<IByronTransactionRequests>()
                .ForgetAsync(
                    ByronWalletModel.Id,
                    transaction.Content.Id);

            Assert.IsNull(result.CardanoHttpResponseModel);
        }
    }
}
