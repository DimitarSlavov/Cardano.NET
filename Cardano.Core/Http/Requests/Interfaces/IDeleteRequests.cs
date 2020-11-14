using Cardano.Core.Models.Common;
using System.Threading.Tasks;

namespace Cardano.Core.Http.Requests.Interfaces
{
    public interface IDeleteRequests
    {
        Task<Response> DeleteAsync(string path);

        Task<Response<TResponseContent>> DeleteAsync<TResponseContent, TRequestBody>(string path, TRequestBody data)
            where TResponseContent : class
            where TRequestBody : class;
    }
}