using Cardano.Core.Models.Common;
using System.Threading.Tasks;

namespace Cardano.Core.Http.Requests.Interfaces
{
    public interface IPostRequests
    {
        Task<Response<TResponseContent>> PostAsync<TResponseContent, TRequestBody>(string path, TRequestBody data, string requestContentType = null)
            where TResponseContent : class
            where TRequestBody : class;
    }
}