using Cardano.Core.Http.Requests.Interfaces;
using Cardano.Core.Json.Interfaces;
using Cardano.Core.Models.Common;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Cardano.Core.Http.Requests.Implementations
{
    internal class DeleteRequests : IDeleteRequests
    {
        private readonly HttpClient httpClient;
        private readonly IJsonSerializer jsonSerializer;

        public DeleteRequests(IHttpClientFactory httpClientFactory,
            IJsonSerializer jsonSerializer)
        {
            httpClient = httpClientFactory.CreateClient(RequestsBase.HttpClientName);
            this.jsonSerializer = jsonSerializer;
        }

        public async Task<Response> DeleteAsync(
            string path)
        {
            using (var httpResponse = await httpClient.DeleteAsync(path))
            {
                var content = await httpResponse.Content.ReadAsStringAsync();

                var result = Response.GetResponse(httpResponse.ReasonPhrase, httpResponse.StatusCode);

                if (content != null)
                {
                    var httpResponseModel = jsonSerializer.Deserialize<CardanoHttpResponseModel>(content);
                    result.CardanoHttpResponseModel = httpResponseModel;
                }

                return result;
            }
        }

        public async Task<Response<TResponseContent>> DeleteAsync<TResponseContent, TRequestBody>(
            string path,
            TRequestBody data)
            where TResponseContent : class
            where TRequestBody : class
        {
            var dataAsString = jsonSerializer.Serialize(data);

            using (var httpContent = new StringContent(dataAsString, Encoding.UTF8, MediaTypeNames.Application.Json))
            {
                using (var httpRequestMessage = new HttpRequestMessage())
                {
                    httpRequestMessage.Method = HttpMethod.Delete;
                    httpRequestMessage
                        .Headers
                        .Accept
                        .Add(new MediaTypeWithQualityHeaderValue(MediaTypeNames.Application.Json));
                    httpRequestMessage.Content = httpContent;
                    httpRequestMessage.RequestUri = HttpHelper.NodeUrlFormat(httpClient.BaseAddress, path);

                    using (var httpResponse = await httpClient.SendAsync(httpRequestMessage))
                    {
                        var content = await httpResponse.Content.ReadAsStringAsync();

                        var result = Response<TResponseContent>.GetResponse(httpResponse.ReasonPhrase, httpResponse.StatusCode);

                        var error = jsonSerializer.Deserialize<CardanoHttpResponseModel>(content);

                        if (error != null &&
                            error.Code != null)
                        {
                            result.CardanoHttpResponseModel = error;

                            return result;
                        }

                        var model = jsonSerializer.Deserialize<TResponseContent>(content);
                        result.Content = model;

                        return result;
                    }
                }
            }
        }
    }
}
