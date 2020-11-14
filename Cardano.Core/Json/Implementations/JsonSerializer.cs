using Cardano.Core.Json.Interfaces;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using JsonSerializerNet = System.Text.Json.JsonSerializer;

namespace Cardano.Core.Json.Implementations
{
    internal class JsonSerializer : IJsonSerializer
    {
        private readonly JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions
        {
            DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        public async Task<T> DeserializeAsync<T>(Stream stream)
            where T : class
        {
            stream.Position = default(int);

            return await JsonSerializerNet.DeserializeAsync<T>(stream, jsonSerializerOptions);
        }

        public T Deserialize<T>(string content)
            where T : class
        {
            return JsonSerializerNet.Deserialize<T>(content, jsonSerializerOptions);
        }

        public T Deserialize<T>(object content)
            where T : class
        {
            return JsonSerializerNet.Deserialize<T>(content?.ToString(), jsonSerializerOptions);
        }

        public string Serialize<T>(T data)
            where T : class
        {
            return JsonSerializerNet.Serialize(data, jsonSerializerOptions);
        }
    }
}
