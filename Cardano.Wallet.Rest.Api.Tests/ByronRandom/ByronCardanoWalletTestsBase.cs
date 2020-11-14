using Cardano.Core.Nomenclatures;
using Cardano.Core.Models.Common;
using Cardano.Wallet.Rest.Api.Interfaces.ByronRandom;
using Cardano.Wallet.Rest.Api.Models.Address;
using Cardano.Wallet.Rest.Api.Models.Byron.Address;
using Cardano.Wallet.Rest.Api.Models.Byron.Wallet;
using Cardano.Wallet.Rest.Api.Models.Common;
using Cardano.Wallet.Rest.Api.Models.Transaction;
using Cardano.Wallet.Rest.Api.Models.Wallet;
using Cardano.Wallet.Rest.Api.Tests.Common;
using Cardano.Wallet.Rest.Api.Tests.Helpers;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cardano.Wallet.Rest.Api.Tests.ByronRandom
{
    /// <summary>
    /// Restore Ledger Wallet, Icarus Wallet and Random Style Wallet to complete tests. 
    /// Wallets must have funds to complete all tests.
    /// </summary>
    internal abstract class ByronCardanoWalletTestsBase : WalletTestsBase
    {
        protected ByronWalletModel ByronWalletModel { get; set; }

        //protected TService GetByronService<TService>()
        //{
        //    var services = new ServiceCollection();

        //    services.AddByronServices();

        //    var serviceProvider = services.BuildServiceProvider();

        //    var service = serviceProvider.GetService<TService>();

        //    return service;
        //}

        protected async Task OneTimeTearDownBase()
        {
            await SleepAsync();

            await RemoveTestWallet();
        }

        protected async Task<Response<ByronWalletModel>> CreateWalletAsync<TModel>(TModel walletModel)
            where TModel : ByronWalletMetadata
        {
            return await GetCardanoWalletService<IByronWalletRequests>()
                .RestoreAsync(walletModel);
        }

        protected async Task<ByronWalletModel> CreateTestWalletAsync()
        {
            var wallets = await GetWalletListAsync();

            var testWallet = wallets.Content.FirstOrDefault(w => w.Name == ByronWalletHelper.WalletStyleRandom.Name);

            if (testWallet != null)
            {
                return testWallet;
            };

            var createdWallet = await CreateWalletAsync(ByronWalletHelper.WalletStyleRandom);

            return createdWallet.Content;
        }

        protected async Task RemoveTestWallet()
        {
            var wallets = await GetWalletListAsync();

            var byronRandomWallet = wallets.Content.FirstOrDefault(w => w.Name == ByronWalletHelper.WalletStyleRandom.Name);

            if (byronRandomWallet != null
                && byronRandomWallet.Balance.Total.Quantity == default(int))
            {
                await DeleteWalletAsync(byronRandomWallet.Id);
            }
        }

        protected async Task<Response<IEnumerable<ByronWalletModel>>> GetWalletListAsync()
        {
            return await GetCardanoWalletService<IByronWalletRequests>()
                .GetListAsync();
        }

        protected async Task<Response> DeleteWalletAsync(string walletId)
        {
            return await GetCardanoWalletService<IByronWalletRequests>()
                .DeleteAsync(walletId);
        }

        protected async Task<Response<Address>> CreateAddressAsync()
        {
            var addressCreationCredentials = new AddressCreationCredentials
            {
                Passphrase = ByronWalletHelper.WalletStyleRandom.Passphrase
            };

            return await GetCardanoWalletService<IByronAddressRequests>()
                .CreateAddressAsync(
                    ByronWalletModel.Id,
                    addressCreationCredentials);
        }

        protected async Task<Response<ByronWalletModel>> UpdateMetadataAsync(string walletId, string walletName)
        {
            var walletMetadata = new ByronWalletMetadata
            {
                Name = walletName
            };

            return await GetCardanoWalletService<IByronWalletRequests>()
                .UpdateMetadataAsync(
                    walletId,
                    walletMetadata);
        }

        protected async Task<Response> UpdatePassphraseAsync(string walletId, string newPassphrase, string oldPassphrase = null)
        {
            var walletPassphraseModel = new PassphraseUpdateResponse
            {
                OldPassphrase = oldPassphrase ?? ByronWalletHelper.Passphrase,
                NewPassphrase = newPassphrase
            };

            return await GetCardanoWalletService<IByronWalletRequests>()
                .UpdatePassphraseAsync(
                    walletId,
                    walletPassphraseModel);
        }

        protected async Task<Response<IEnumerable<Address>>> GetAddressListAsync(string walletId = null)
        {
            return await GetCardanoWalletService<IByronAddressRequests>()
                .GetListAsync(walletId ?? ByronWalletModel.Id);
        }

        protected async Task<Response<ByronWalletModel>> GetWalletByIdAsync(string walletId)
        {
            return await GetCardanoWalletService<IByronWalletRequests>()
                .GetByIdAsync(walletId);
        }
        
        protected async Task<string> GetIcarusWalletIdAsync()
        {
            var wallets = await GetWalletListAsync();

            Assert.NotNull(wallets.Content);

            return wallets.Content
                .First(w => w.Name == ByronWalletHelper.WalletStyleIcarus.Name).Id;
        }

        protected async Task<string> GetUsedAddressForIcarusWalletAsync()
        {
            var walletId = await GetIcarusWalletIdAsync();

            Assert.NotNull(walletId);

            var addresses = await GetAddressListAsync(walletId);

            Assert.NotNull(addresses.Content);

            return addresses.Content.First(a => a.State == AddressStateEnum.Used.GetValue()).Id;
        }

        protected async Task<Response<Transaction>> CreateTransactionAsync(string address, string walletId = null, ulong quantity = DefaultQuantity)
        {
            var payments = new TransactionCreationArguments
            {
                Payments = new Payment[]
                    {
                        new Payment
                        {
                            Address = address,
                            Amount = new Fund
                            {
                                Quantity = quantity
                            }
                        }
                    },
                Passphrase = ByronWalletHelper.Passphrase
            };

            return await GetCardanoWalletService<IByronTransactionRequests>()
                .CreateAsync(
                    walletId ?? ByronWalletModel.Id,
                    payments);
        }
    }
}
