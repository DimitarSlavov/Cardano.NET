using Cardano.Explorer.Rest.Api.Models.Common;
using System.Collections.Generic;
using System.Linq;
using Cardano.Core.Json.Interfaces;

namespace Cardano.Explorer.Rest.Api.Models
{
    public class BlockPage: PolytypeBase<List<object>>
    {
        public BlockPage(List<object> data, 
            IJsonSerializer jsonSerializer) 
            : base(data, jsonSerializer)
        {
        }

        public override List<object> Data 
        { 
            set
            {
                if (ulong.TryParse(value.ElementAt(0).ToString(), out var pageNumber))
                {
                    PageNumber = pageNumber;
                }

                this.Blocks = jsonSerializer.Deserialize<List<Block>>(value.ElementAt(1));
            } 
        }

        public ulong PageNumber { get; private set; }

        public List<Block> Blocks { get; private set; }
    }
}
