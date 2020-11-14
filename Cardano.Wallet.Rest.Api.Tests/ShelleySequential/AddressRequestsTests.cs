using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace Cardano.Wallet.Rest.Api.Tests.ShelleySequential
{
    [TestFixture]
    internal class AddressRequestsTests : ShellyCardanoWalletTestsBase
    {
        [OneTimeSetUp]
        public async Task SetUp()
        {
            var wallet = await CreateTestWalletAsync();

            ShellyWalletModel = wallet;
        }

        [OneTimeTearDown]
        public async Task OneTimeTearDown() => await OneTimeTearDownBase();

        [Test]
        public async Task TestGetListAsync()
        {
            var result = await GetAddressListAsync();

            Assert.True(result.Content.Any());
        }
    }
}
