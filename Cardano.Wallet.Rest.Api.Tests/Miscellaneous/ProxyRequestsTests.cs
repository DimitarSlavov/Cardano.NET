﻿using Cardano.Wallet.Rest.Api.Interfaces.Miscellaneous;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Cardano.Wallet.Rest.Api.Tests.Miscellaneous
{
    internal class ProxyRequestsTests : MiscellaneousRequestsTestsBase
    {
        //[Test]
        public async Task TestPostExternalTransactionAsync()
        {
            var result = await GetCardanoWalletService<IProxyRequests>()
                .PostExternalTransactionAsync(System.Text.Encoding.ASCII.GetBytes("82839f8200d81858248258201d4ca4d72a1e02fbb79bec42392d9eb3da179f8a2316fd9e9a5ffe9c441d8bce01ff9f8282d818582883581c9c19ec69f7d3acad269e4bbbfcad67129c268bd772060b426b7e23cba102451a4170cb17001a1c281652018282d818582883581c95eaa323cac6cd8916a02c58b133d9b576ceb7bcb1f8c0716a701118a102451a4170cb17001a5e6fce581a0096048effa0818200d8185885825840b8cdd384ec1ef3dffe4db999d6bfce40afaa964543e2e1592c932f552fe9e8301233bbc1f45472837b904b719db5d32d947ec521e7fccd1aec6ad6cf884fc45858403964714f761d79a67b34c8e1fcc337af6ef44a894e6e740927dbec86d1be63e9987dc9ceb7905a53a0ddddf3a9ea4508e41a02d18ed3994461eb20cb0ba2710b"));
            
            AssertOK(result.CardanoHttpResponseModel);
        }
    }
}
