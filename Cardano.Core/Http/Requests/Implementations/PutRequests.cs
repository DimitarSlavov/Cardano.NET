using Cardano.Core.Http.Requests.Interfaces;
using Cardano.Core.Json.Interfaces;
using Cardano.Core.Models.Common;
using System.Net.Http;
using System.Net.Mime;
using System.Threading.Tasks;

namespace Cardano.Core.Http.Requests.Implementations
{
    internal class PutRequests : IPutRequests
    {
        private readonly HttpClient httpClient;
        private readonly IJsonSerializer jsonSerializer;

        public PutRequests(IHttpClientFactory httpClientFactory,
            IJsonSerializer jsonSerializer)
        {
            httpClient = httpClientFactory.CreateClient(RequestsBase.HttpClientName);
            this.jsonSerializer = jsonSerializer;
        }

        public async Task<Response<TResponseContent>> PutAsync<TResponseContent, TRequestBody>(
            string path,
            TRequestBody data)
            where TResponseContent : class
            where TRequestBody : class
        {
            var dataAsString = jsonSerializer.Serialize(data);

            using (var httpContent = new StringContent(dataAsString))
            {
                httpContent.Headers.ContentType.MediaType = MediaTypeNames.Application.Json;

                using (var httpResponse = await httpClient.PutAsync(path, httpContent))
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

        public async Task<Response> PutAsync<TRequestBody>(
            string path,
            TRequestBody data)
            where TRequestBody : class
        {
            var dataAsString = jsonSerializer.Serialize(data);

            using (var httpContent = new StringContent(dataAsString))
            {
                httpContent.Headers.ContentType.MediaType = MediaTypeNames.Application.Json;

                using (var httpResponse = await httpClient.PutAsync(path, httpContent))
                {
                    var content = await httpResponse.Content.ReadAsStringAsync();

                    var result = Response.GetResponse(httpResponse.ReasonPhrase, httpResponse.StatusCode);

                    if (!string.IsNullOrEmpty(content))
                    {
                        var httpResponseModel = jsonSerializer.Deserialize<CardanoHttpResponseModel>(content);
                        result.CardanoHttpResponseModel = httpResponseModel;
                    }

                    return result;
                }
            }
        }

        public async Task<Response> PutAsync(
            string path)
        {
            using (var httpRequesMessage = new HttpRequestMessage
            {
                RequestUri = HttpHelper.NodeUrlFormat(httpClient.BaseAddress, path),
                Method = HttpMethod.Put
            })
            {
                using (var httpResponse = await httpClient.SendAsync(httpRequesMessage))
                {
                    var content = await httpResponse.Content.ReadAsStringAsync();
                    
                    var result = Response.GetResponse(httpResponse.ReasonPhrase, httpResponse.StatusCode);

                    if (!string.IsNullOrEmpty(content))
                    {
                        var httpResponseModel = jsonSerializer.Deserialize<CardanoHttpResponseModel>(content);

                        result.CardanoHttpResponseModel = httpResponseModel;
                    }

                    return result;
                }
            }
        }
    }
}
