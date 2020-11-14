using Cardano.Wallet.Rest.Api.Interfaces.ShelleySequential;
using Cardano.Wallet.Rest.Api.Models.Common;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace Cardano.Wallet.Rest.Api.Tests.ShelleySequential
{
    [TestFixture]
    internal class TransactionRequestsTests : ShellyCardanoWalletTestsBase
    {
        private string Address { get; set; }

        [SetUp]
        public async Task SetUp()
        {
            await SleepAsync(500);
        }

        [OneTimeSetUp]
        public async Task OneTimeSetUp()
        {
            await RemoveWallet();

            await SleepAsync();

            var result = await CreateTestWalletAsync();

            ShellyWalletModel = result;

            Address = await GetUsedAddressForXpubWalletAsync();
        }

        [OneTimeTearDown]
        public async Task OneTimeTearDown() => await OneTimeTearDownBase();

        [Test, Order(1)]
        public async Task TestEstimateFeeAsync()
        {
            var randomSelection = new RandomSelection
            {
                Payments = new Payment[]
                {
                    new Payment
                    {
                        Address = Address,
                        Amount = new Fund
                        {
                            Quantity = DefaultQuantity
                        }
                    }
                }
            };

            var result = await GetCardanoWalletService<ITransactionRequests>()
                .EstimateFeeAsync(
                    ShellyWalletModel.Id,
                    randomSelection);

            Assert.NotNull(result.Content);
        }

        [Test, Order(3)]
        public async Task TestCreateTransactionAsync()
        {
            var result = await CreateTransactionAsync(Address);

            Assert.NotNull(result.Content);
        }

        [Test, Order(2)]
        public async Task TestGetTransactionListAsync()
        {
            var result = await GetCardanoWalletService<ITransactionRequests>()
                .GetListAsync(ShellyWalletModel.Id);

            Assert.True(result.Content.Any());
        }

        [Test, Order(4)]
        public async Task TestGetTransactionByIdAsync()
        {
            var transactions = await GetCardanoWalletService<ITransactionRequests>()
                .GetListAsync(ShellyWalletModel.Id);

            Assert.True(transactions.Content.Any());

            var result = await GetCardanoWalletService<ITransactionRequests>()
                .GetByIdAsync(
                    ShellyWalletModel.Id, 
                    transactions.Content.First().Id);

            Assert.NotNull(result.Content);
        }

        [Test, Order(5)]
        public async Task TestForgetAsync()
        {
            var transaction = await CreateTransactionAsync(Address);

            Assert.NotNull(transaction.Content);

            var result = await GetCardanoWalletService<ITransactionRequests>()
                .ForgetAsync(
                    ShellyWalletModel.Id,
                    transaction.Content.Id);

            Assert.IsNull(result.CardanoHttpResponseModel);
        }
    }
}
