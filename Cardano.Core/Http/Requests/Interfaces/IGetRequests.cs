using Cardano.Core.Models.Common;
using System.Threading.Tasks;

namespace Cardano.Core.Http.Requests.Interfaces
{
    public interface IGetRequests
    {
        Task<Response<TRequestBody>> GetAsync<TRequestBody>(string path) 
            where TRequestBody : class;
    }
}