using Cardano.Wallet.Rest.Api.Interfaces.ShelleySequential;
using Cardano.Wallet.Rest.Api.Tests.Helpers;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Cardano.Wallet.Rest.Api.Tests.ShelleySequential
{
    internal class WalletRequestsTests : ShellyCardanoWalletTestsBase
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
        public async Task TestCreateOrRestoreAsync()
        {
            var createdWallet = await CreateWalletAsync(ShellyWalletHelper.WalletTest2);

            Assert.NotNull(createdWallet.Content);

            var createdWalletId = createdWallet.Content.Id;

            var wallet = await GetWalletByIdAsync(createdWalletId);

            await SleepAsync();

            await DeleteWalletAsync(createdWalletId);

            Assert.AreEqual(createdWalletId, wallet.Content.Id);
        }

        [Test]
        public async Task TestGetListAsync()
        {
            var result = await GetWalletListAsync();

            AssertOK(result.CardanoHttpResponseModel);
        }

        [Test]
        public async Task TestGetUTxOStatisticsAsync()
        {
            var result = await GetCardanoWalletService<IWalletRequests>()
                .GetUTxOStatisticsAsync(ShellyWalletModel.Id);

            AssertOK(result.CardanoHttpResponseModel);
        }

        [Test]
        public async Task TestGetByIdAsync()
        {
            var result = await GetWalletByIdAsync(ShellyWalletModel.Id);

            Assert.AreEqual(ShellyWalletModel.Id, result.Content.Id);
        }

        [Test]
        public async Task TestDeleteAsync()
        {
            var wallet = await CreateWalletAsync(ShellyWalletHelper.WalletTest2);

            Assert.NotNull(wallet.Content);

            await SleepAsync();

            var result = await DeleteWalletAsync(wallet.Content.Id);

            AssertOK(result.CardanoHttpResponseModel);
        }

        [Test]
        public async Task TestUpdateMetadataAsync()
        {
            const string randomName = "Random_Name_146CAE6D-940E-4813-8DA6-FA0A04178AC4";
            var walletId = ShellyWalletModel.Id;
            var updatedWallet = await UpdateMetadataAsync(walletId, randomName);

            Assert.NotNull(updatedWallet.Content);

            if (walletId == updatedWallet.Content.Id)
            {
                Assert.AreEqual(randomName, updatedWallet.Content.Name);

                var originalName = ShellyWalletHelper.WalletIcarus.Name;
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
            var walletId = ShellyWalletModel.Id;

            var updatePassphraseResponse = await UpdatePassphraseAsync(walletId, newPassphrase);

            Assert.IsNull(updatePassphraseResponse.CardanoHttpResponseModel);

            var lastUpdated = ShellyWalletModel.Passphrase.LastUpdatedAt;

            var updatedWallet = await GetWalletByIdAsync(walletId);

            if (walletId == updatedWallet.Content.Id)
            {
                var nowUpdated = updatedWallet.Content.Passphrase.LastUpdatedAt;

                Assert.AreNotEqual(lastUpdated, nowUpdated);

                var restorePassphraseResponse = await UpdatePassphraseAsync(walletId, ShellyWalletHelper.Passphrase, newPassphrase);

                Assert.IsNull(restorePassphraseResponse.CardanoHttpResponseModel);

                var restoredWallet = await GetWalletByIdAsync(walletId);

                Assert.AreNotEqual(nowUpdated, restoredWallet.Content.Passphrase.LastUpdatedAt);

                Assert.Pass();
            }

            Assert.Fail();
        }
    }
}
