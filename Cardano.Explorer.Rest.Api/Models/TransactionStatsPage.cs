using Cardano.Core.Json.Interfaces;
using Cardano.Explorer.Rest.Api.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cardano.Explorer.Rest.Api.Models
{
    public class TransactionStatsPage: PolytypeBase<List<object>>
    {
        public TransactionStatsPage(List<object> data, 
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

                this.TransactionStatsList = jsonSerializer.Deserialize<List<Tuple<string, ulong>>>(value.ElementAt(1));
            }
        }

        public ulong PageNumber { get; private set; }

        /// <summary>
        /// List of tuples where: 
        /// The first element is a transaction hash. 
        /// The second element is the size of that transaction in bytes.
        /// </summary>
        public List<Tuple<string, ulong>> TransactionStatsList { get; private set; }
    }
}
