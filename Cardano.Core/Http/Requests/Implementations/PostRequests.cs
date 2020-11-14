using Cardano.Core.Http.Requests.Interfaces;
using Cardano.Core.Json.Interfaces;
using Cardano.Core.Models.Common;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Threading.Tasks;

namespace Cardano.Core.Http.Requests.Implementations
{
    internal class PostRequests : IPostRequests
    {
        private readonly HttpClient httpClient;
        private readonly IJsonSerializer jsonSerializer;

        public PostRequests(IHttpClientFactory httpClientFactory,
            IJsonSerializer jsonSerializer)
        {
            httpClient = httpClientFactory.CreateClient(RequestsBase.HttpClientName);
            this.jsonSerializer = jsonSerializer;
        }

        public async Task<Response<TResponseContent>> PostAsync<TResponseContent, TRequestBody>(
            string path,
            TRequestBody data,
            string requestContentType = null)
            where TResponseContent : class
            where TRequestBody : class
        {
            HttpContent httpContent;

            try
            {
                if (typeof(TRequestBody) == typeof(string))
                {
                    httpContent = new StringContent(data as string);
                }
                else if (typeof(TRequestBody) == typeof(byte[]))
                {
                    httpContent = new ByteArrayContent(data as byte[]);
                }
                else
                {
                    httpContent = new StringContent(jsonSerializer.Serialize(data));
                }

                if (!string.IsNullOrEmpty(requestContentType))
                {
                    if (httpContent.Headers?.ContentType?.MediaType != null)
                    {
                        httpContent.Headers.ContentType.MediaType = requestContentType;
                    }
                    else
                    {
                        httpContent.Headers.ContentType = new MediaTypeHeaderValue(requestContentType);
                    }
                }
                else
                {
                    httpContent.Headers.ContentType.MediaType = MediaTypeNames.Application.Json;
                }

                using (var httpResponse = await httpClient.PostAsync(path, httpContent))
                {
                    var result = Response<TResponseContent>.GetResponse(httpResponse.ReasonPhrase, httpResponse.StatusCode);

                    var content = await httpResponse.Content.ReadAsStringAsync();

                    if (content == null)
                    {
                        return result;
                    }

                    try
                    {
                        var error = jsonSerializer.Deserialize<CardanoHttpResponseModel>(content);

                        if (error.Message != null && error.Code != null)
                        {
                            result.CardanoHttpResponseModel = new CardanoHttpResponseModel
                            {
                                Message = error.Message,
                                Code = error.Code
                            };

                            return result;
                        }
                    }
                    catch { }

                    var model = jsonSerializer.Deserialize<TResponseContent>(content);

                    result.Content = model;

                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
