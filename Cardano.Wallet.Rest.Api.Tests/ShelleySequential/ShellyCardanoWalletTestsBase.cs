using Cardano.Core.Nomenclatures;
using Cardano.Core.Models.Common;
using Cardano.Wallet.Rest.Api.Interfaces.ShelleySequential;
using Cardano.Wallet.Rest.Api.Models.Address;
using Cardano.Wallet.Rest.Api.Models.Common;
using Cardano.Wallet.Rest.Api.Models.Shelly;
using Cardano.Wallet.Rest.Api.Models.Transaction;
using Cardano.Wallet.Rest.Api.Models.Wallet;
using Cardano.Wallet.Rest.Api.Tests.Common;
using Cardano.Wallet.Rest.Api.Tests.Helpers;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cardano.Wallet.Rest.Api.Tests.ShelleySequential
{
    internal abstract class ShellyCardanoWalletTestsBase : WalletTestsBase
    {
        protected ShellyWalletModel ShellyWalletModel { get; set; }

        //protected TService GetShelleyService<TService>()
        //{
        //    IServiceCollection services = new ServiceCollection();

        //    services.AddShelleyServices();

        //    var serviceProvider = services.BuildServiceProvider();

        //    var service = serviceProvider.GetService<TService>();

        //    return service;
        //}

        protected async Task<Response<ShellyWalletModel>> CreateWalletAsync<TModel>(TModel walletModel)
            where TModel : WalletModelBase
        {
            return await GetCardanoWalletService<IWalletRequests>()
                .CreateOrRestoreAsync(walletModel);
        }

        protected async Task<Response<IEnumerable<ShellyWalletModel>>> GetWalletListAsync()
        {
            return await GetCardanoWalletService<IWalletRequests>()
                .GetListAsync();
        }

        protected async Task<ShellyWalletModel> CreateTestWalletAsync()
        {
            var wallets = await GetWalletListAsync();

            var testWallet = wallets.Content.FirstOrDefault(w => w.Name == ShellyWalletHelper.WalletIcarus.Name);

            if (testWallet != null)
            {
                return testWallet;
            };

            var createdWallet = await CreateWalletAsync(ShellyWalletHelper.WalletIcarus);

            Assert.NotNull(createdWallet.Content);

            return createdWallet.Content;
        }

        protected async Task RemoveWallet(string walletName = null)
        {
            if (walletName == null)
            {
                walletName = ShellyWalletHelper.WalletIcarus.Name;
            }

            var wallets = await GetWalletListAsync();

            var shellyWallet = wallets.Content.FirstOrDefault(w => w.Name == walletName);

            if (shellyWallet != null
                && shellyWallet.Balance.Total.Quantity == default(int))
            {
                await DeleteWalletAsync(shellyWallet.Id);
            }
        }

        protected async Task<Response> DeleteWalletAsync(string walletId)
        {
            return await GetCardanoWalletService<IWalletRequests>()
                .DeleteAsync(walletId);
        }

        protected async Task<Response<ShellyWalletModel>> GetWalletByIdAsync(string walletId)
        {
            return await GetCardanoWalletService<IWalletRequests>()
                .GetByIdAsync(walletId);
        }

        protected async Task OneTimeTearDownBase()
        {
            await SleepAsync();

            await RemoveWallet();
        }

        protected async Task<Response<ShellyWalletModel>> UpdateMetadataAsync(string walletId, string walletName)
        {
            var walletMetadata = new ShellyWalletModel
            {
                Name = walletName
            };

            return await GetCardanoWalletService<IWalletRequests>()
                .UpdateMetadataAsync(
                    walletId,
                    walletMetadata);
        }

        protected async Task<Response> UpdatePassphraseAsync(string walletId, string newPassphrase, string oldPassphrase = null)
        {
            var walletPassphraseModel = new PassphraseUpdateResponse
            {
                OldPassphrase = oldPassphrase ?? ShellyWalletHelper.Passphrase,
                NewPassphrase = newPassphrase
            };

            return await GetCardanoWalletService<IWalletRequests>()
                .UpdatePassphraseAsync(
                    walletId,
                    walletPassphraseModel);
        }

        protected async Task<Response<IEnumerable<Address>>> GetAddressListAsync(string walletId = null)
        {
            return await GetCardanoWalletService<IAddressRequests>()
                .GetListAsync(walletId ?? ShellyWalletModel.Id);
        }

        protected async Task<string> GetXpubWalletIdAsync()
        {
            var wallets = await GetWalletListAsync();

            Assert.NotNull(wallets.Content);

            return wallets.Content
                .First(w => w.Name == ShellyWalletHelper.NonRandomWalletFromXpub.Name).Id;
        }

        protected async Task<string> GetUsedAddressForXpubWalletAsync()
        {
            var walletId = await GetXpubWalletIdAsync();

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
                Passphrase = ShellyWalletHelper.Passphrase
            };

            return await GetCardanoWalletService<ITransactionRequests>()
                .CreateAsync(
                    walletId ?? ShellyWalletModel.Id,
                    payments);
        }
    }
}
