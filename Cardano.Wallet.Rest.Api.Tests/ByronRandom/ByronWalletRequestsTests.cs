using Cardano.Wallet.Rest.Api.Interfaces.ByronRandom;
using Cardano.Wallet.Rest.Api.Models.Byron.Wallet;
using Cardano.Wallet.Rest.Api.Tests.Helpers;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace Cardano.Wallet.Rest.Api.Tests.ByronRandom
{
    [TestFixture]
    internal class ByronWalletRequestsTests : ByronCardanoWalletTestsBase
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
        public async Task TestGetListAsync()
        {
            var result = await GetWalletListAsync();

            Assert.That(result.Content != null && result.Content.Any());  
        }

        [Test]
        public async Task TestRestoreAsync()
        {
            var createdWallet = await CreateWalletAsync(ByronWalletHelper.RandomWalletFromXprv);

            Assert.NotNull(createdWallet.Content);

            var createdWalletId = createdWallet.Content.Id;

            var wallet = await GetWalletByIdAsync(createdWalletId);

            await SleepAsync();

            await DeleteWalletAsync(createdWalletId);

            Assert.AreEqual(createdWalletId, wallet.Content.Id);
        }

        [Test]
        public async Task TestGetByIdAsync()
        {
            var result = await GetWalletByIdAsync(ByronWalletModel.Id);

            Assert.AreEqual(ByronWalletModel.Id, result.Content.Id);
        }

        [Test]
        public async Task TestDeleteAsync()
        {
            var wallet = await CreateWalletAsync(ByronWalletHelper.RandomWalletFromXprv);

            Assert.NotNull(wallet.Content);

            await SleepAsync();

            var result = await DeleteWalletAsync(wallet.Content.Id);

            AssertOK(result.CardanoHttpResponseModel);
        }

        [Test]
        public async Task TestUpdateMetadataAsync()
        {
            const string randomName = "Random_Name_B6C86DEF-9B2C-46AF-9713-877C8633AE1E";
            var walletId = ByronWalletModel.Id;
            var updatedWallet = await UpdateMetadataAsync(walletId, randomName);

            Assert.NotNull(updatedWallet.Content);

            if (walletId == updatedWallet.Content.Id)
            {
                Assert.AreEqual(randomName, updatedWallet.Content.Name);

                var originalName = ByronWalletHelper.WalletStyleRandom.Name;
                var restoredWallet = await UpdateMetadataAsync(walletId, originalName);

                Assert.NotNull(restoredWallet.Content);

                Assert.AreEqual(originalName, restoredWallet.Content.Name);

                Assert.Pass();
            }

            Assert.Fail();
        }

        [Test]
        public async Task TestUpdatePassphraseAsync()
        {
            const string newPassphrase = "Secure_Random_Passphrase_0B741137-E005-40C6-ADCA-A79B8A1847F5";
            var walletId = ByronWalletModel.Id;

            var updatePassphraseResponse = await UpdatePassphraseAsync(walletId, newPassphrase);

            Assert.IsNull(updatePassphraseResponse.CardanoHttpResponseModel);

            var lastUpdated = ByronWalletModel.Passphrase.LastUpdatedAt;

            var updatedWallet = await GetWalletByIdAsync(walletId);

            if (walletId == updatedWallet.Content.Id)
            {
                var nowUpdated = updatedWallet.Content.Passphrase.LastUpdatedAt;

                Assert.AreNotEqual(lastUpdated, nowUpdated);

                var restorePassphraseResponse = await UpdatePassphraseAsync(walletId, ByronWalletHelper.Passphrase, newPassphrase);

                Assert.IsNull(restorePassphraseResponse.CardanoHttpResponseModel);

                var restoredWallet = await GetWalletByIdAsync(walletId);

                Assert.AreNotEqual(nowUpdated, restoredWallet.Content.Passphrase.LastUpdatedAt);

                Assert.Pass();
            }

            Assert.Fail();
        }

        [Test]
        public async Task TestGetUTxOStatisticsAsync()
        {
            var result = await GetCardanoWalletService<IByronWalletRequests>()
                .GetUTxOStatisticsAsync(ByronWalletModel.Id);

            AssertOK(result.CardanoHttpResponseModel);
        }
    }
}
