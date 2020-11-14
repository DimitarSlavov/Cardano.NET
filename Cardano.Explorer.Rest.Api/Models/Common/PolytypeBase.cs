using Cardano.Core.Json.Interfaces;

namespace Cardano.Explorer.Rest.Api.Models.Common
{
    public abstract class PolytypeBase<TData>
    {
        protected readonly IJsonSerializer jsonSerializer;

        public PolytypeBase(TData data,
            IJsonSerializer jsonSerializer)
        {
            Data = data;
            this.jsonSerializer = jsonSerializer;
        }

        public abstract TData Data { set; }
    }
}
