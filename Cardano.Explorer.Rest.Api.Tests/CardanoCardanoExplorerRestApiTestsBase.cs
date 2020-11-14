using Cardano.Core.Models.Common;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Cardano.Explorer.Rest.Api.Tests
{
    internal class CardanoCardanoExplorerRestApiTestsBase
    {
        protected TService GetExplorerService<TService>()
        {
            var services = new ServiceCollection();

            services.AddExplorerServices();

            var serviceProvider = services.BuildServiceProvider();

            var service = serviceProvider.GetService<TService>();

            return service;
        }

        protected void AssertOK(CardanoHttpResponseModel model)
        {
            if (model == null)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }
    }
}