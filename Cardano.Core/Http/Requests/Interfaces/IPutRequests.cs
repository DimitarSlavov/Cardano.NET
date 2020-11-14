using Cardano.Core.Models.Common;
using System.Threading.Tasks;

namespace Cardano.Core.Http.Requests.Interfaces
{
    public interface IPutRequests
    {
        Task<Response> PutAsync(string path);

        Task<Response> PutAsync<TRequestBody>(string path, TRequestBody data) 
            where TRequestBody : class;

        Task<Response<TResponseContent>> PutAsync<TResponseContent, TRequestBody>(string path, TRequestBody data)
            where TResponseContent : class
            where TRequestBody : class;
    }
}