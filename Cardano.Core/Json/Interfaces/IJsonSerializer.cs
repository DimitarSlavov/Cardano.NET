using System.IO;
using System.Threading.Tasks;

namespace Cardano.Core.Json.Interfaces
{
    public interface IJsonSerializer
    {
        Task<T> DeserializeAsync<T>(Stream stream)
            where T : class;

        T Deserialize<T>(string content)
            where T : class;

        T Deserialize<T>(object content)
            where T : class;

        string Serialize<T>(T data)
            where T : class;
    }
}
