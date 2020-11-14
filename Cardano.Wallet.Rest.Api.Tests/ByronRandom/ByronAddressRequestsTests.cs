using Cardano.Wallet.Rest.Api.Interfaces.ByronRandom;
using Cardano.Wallet.Rest.Api.Models.Address;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace Cardano.Wallet.Rest.Api.Tests.ByronRandom
{
    [TestFixture]
    internal class ByronAddressRequestsTests : ByronCardanoWalletTestsBase
    {
        private Address Address { get; set; }

        [OneTimeSetUp]
        public async Task SetUp()
        {
            var wallet = await CreateTestWalletAsync();

            ByronWalletModel = wallet;

            var existingAddresses = await GetAddressListAsync();

            if (!existingAddresses.Content.Any())
            {
                var addresses = await CreateAddressAsync();
                Address = addresses.Content;
            }

            Address = existingAddresses.Content.First();
        }

        [OneTimeTearDown]
        public async Task OneTimeTearDown() => await OneTimeTearDownBase();

        [Test]
        public async Task TestGetListAsync()
        {
            var result = await GetAddressListAsync();

            Assert.True(result.Content.Any());
        }

        [Test]
        public void TestCreateAddress()
        {
            Assert.NotNull(Address);
        }

        [Test]
        public async Task TestImportAddressAsync()
        {
            Assert.NotNull(Address);

            var result = await GetCardanoWalletService<IByronAddressRequests>()
                .ImportAddressAsync(
                    ByronWalletModel.Id,
                    Address.Id);

            Assert.IsNull(result.CardanoHttpResponseModel);
        }
    }
}
