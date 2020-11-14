using Cardano.Core.Models.Common;
using Cardano.Explorer.Rest.Api.Models;
using Cardano.Explorer.Rest.Api.Models.Common;

namespace Cardano.Explorer.Rest.Api.Common
{
    internal static class ResponseExtensions
    {
        public static Response<Right<TModel>> Merge<TModel, TData>(this Response<Right<TData>> response, TModel model)
            where TModel : PolytypeBase<TData>
        {
            return new Response<Right<TModel>>
            {
                Content = new Right<TModel>
                {
                    Result = model
                },
                CardanoHttpResponseModel = response.CardanoHttpResponseModel
            };
        }
    }
}
